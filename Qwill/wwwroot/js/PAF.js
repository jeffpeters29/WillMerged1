// #####################################################################
// ###                      JQUERY PLUGIN                            ###
// #####################################################################
//                GET ADDRESSES FOR POSTCODE-SEARCHTERM  
//
// The user has the choice to keep the DEFAULT fields or CONFIGURE THEIR OWN
// If they want the DEFAULTS, they merely need to have textboxes (or similar) with id's named "Address1", "Address2", "Address3", "Town"
// If they wish to override these defaults, they will need to CONFIGURE THEIR OWN

(function ($) {
    $.fn.paf = function (options) {

        var latestSearch = "";

        //-------------------------------------------------------------
        // SETTINGS        (Combine user defined options with defaults)
        //-------------------------------------------------------------
        var settings = {};
        $.extend(settings, $.fn.paf.DEFAULTS, options);

        //-------------------------------------------------------------
        // USER TYPES IN POSTCODE 
        //-------------------------------------------------------------

        $(options.element).css("text-transform", "uppercase");

        $(options.element).keyup(function () {
            var searchTerm = $(this).val().trim().replace(/ /g, "");

            if (searchTerm.length > 0) {
                $(options.result).addClass("paf");
                $(options.result).show();

                latestSearch = searchTerm;
                getAddressFromService(searchTerm);
            } else {
                $(options.result).removeClass("paf");
                $(options.result).hide();
            }
        });

        //-------------------------------------------------------------
        // SWITCH OFF AUTOCOMPLETE FOR CHROME  (similar feature to pca)
        //-------------------------------------------------------------

        var isChrome = /Chrome/.test(navigator.userAgent) && /Google Inc/.test(navigator.vendor);
        if (isChrome) {
            $(options.element)[0].autocomplete = "ignoreThisFeature";
        }

        //--------------------------------------------------------------
        // GET DATA FROM SERVICE / RENDER
        //--------------------------------------------------------------
        function getAddressFromService(searchTerm) {

            var env = settings.isLive ? "" : "beta";

            $.ajax({
                type: "GET",
                url: "https://" + env + "addressapi.remapkings.com/api/address/GetAddressPostcode?searchTerm=" + searchTerm,                          //url: "xhttp://localhost:57895/api/address/GetAddressPostcode?searchTerm=" + searchTerm,
                crossDomain: true,
                success: function (data) {
                    if (data.searchTerm.toLowerCase() === latestSearch.toLowerCase()) {
                        renderResults(data.addresses);
                    }
                },
                error: function () {
                    renderNoAddresses();
                },
                beforeSend: function (xhr) { xhr.setRequestHeader('Authorization', 'Bearer ' + settings.token); }
            });
        }

        function renderResults(data) {
            var maxRows = settings.maxRows;

            if (typeof (maxRows) !== "number" && typeof (this.options.maxRows) === "number") {
                maxRows = $.fn.paf.DEFAULTS.maxRows;
            }

            var tableTemplate = '<table class="table table-hover table-condensed">#rows#</table>';
            var rowTemplate = "<tr><td class='text-left'#attr#>#address#</td></tr>";
            var table = "";
            var rows = "";

            data.forEach(function (o, i) {
                if (i >= maxRows) { return; }

                rowTemplate = rowTemplate.replace("#attr#", o.isPostcode ? " postcode" : "");
                rows += rowTemplate.replace("#address#", o.formattedText);
            });

            table = tableTemplate.replace("#rows#", rows);

            $(options.result).html(table);
        }

        function renderNoAddresses() {

            var tableTemplate = '<table class="table table-hover table-condensed">#rows#</table>';
            var rowTemplate = "<tr><td class='noMatchingAddress' noMatchingAddress>No matching addresses</td></tr>";

            table = tableTemplate.replace("#rows#", rowTemplate);

            $(options.result).html(table);
        }

        //-------------------------------------------------------------
        // USER CLICKS ON RESULTS TABLE
        //-------------------------------------------------------------

        $(options.result).on("click", "td", function (event) {
            if ($(event.currentTarget).is("[postcode]")) {
                //Populate PAF address fields
                var json = JSON.parse($(event.currentTarget).find("span").html());
                populateFormFields(json);
                logSelectedPostcode(json);
                $(options.result).hide();
            } else {
                //Exit if there is no matching address
                if ($(event.currentTarget).is("[noMatchingAddress]")) return;

                //Get chosen postcode from formatted text
                var address = $(event.currentTarget).html().trim().split(":");
                var postcodeDisplay = address[0].trim();
                var postcode = address[0].trim().replace(' ', '');
                //Populate postcode field
                $(options.element).val(postcodeDisplay);
                //Bring back all addresses for this postcode
                latestSearch = postcode;
                getAddressFromService(postcode);
            }
        });

        //--------------------------------------------------------------
        // POPULATE FORM FIELDS
        //--------------------------------------------------------------
        function populateFormFields(json) {
            var mappedModel = mapModel(json, settings);

            for (var fieldName in mappedModel) {
                if (mappedModel.hasOwnProperty(fieldName)) {
                    $("#" + fieldName).val(mappedModel[fieldName].trim());
                }
            }
        }

        function logSelectedPostcode(json) {
            var mappedModel = mapModel(json, settings);
            var postcode = mappedModel["postcode"].trim();

            var env = settings.isLive ? "" : "beta";

            $.ajax({
                type: "GET",
                url: "https://" + env + "addressapi.remapkings.com/api/address/LogSelectedPostcode?postcode=" + postcode,
                crossDomain: true,
                beforeSend: function (xhr) { xhr.setRequestHeader('Authorization', 'Bearer ' + settings.token); }
            });
        }

        function mapModel(dataModel, settings) {

            // Combine default fields with user-defined (which override the defaults)
            var merged = $.extend({}, $.fn.paf.DEFAULTS.addressFields, settings.addressFields);

            // Mapped model to return
            var result = {};

            for (var fieldName in merged) {
                if (merged.hasOwnProperty(fieldName)) {
                    result[fieldName] = mapFields(merged[fieldName], dataModel);
                }
            }

            result["postcode"] = mapFields("{Postcode}", dataModel);

            return result;
        }

        function mapFields(templateLine, records) {

            //For this templateLine, replace the variables with actual data from the record  (e.g. {SubBuildingName} --> "Flat 2"})

            var variables = [
                'Organisation', 'Department',
                'SubBuildingName', 'BuildingName', 'BuildingNumber', 'POBox',
                'Thoroughfare', 'ThoroughfareDependent', 'Locality', 'LocalityDependent',
                'Town', 'Postcode'];

            for (var i = 0; i < variables.length; i++) {
                var fieldValue = records[variables[i]] || "";

                var regEx = new RegExp("\\{" + variables[i] + "\\}", "g");

                if (variables[i] === "POBox" && fieldValue.length)
                    templateLine = templateLine.replace(regEx, "PO Box " + fieldValue);
                else
                    templateLine = templateLine.replace(regEx, fieldValue);

                templateLine = templateLine.allTrim();
                templateLine = templateLine.replaceAll(', , ', ', ');
                templateLine = templateLine.replaceAll('- - ', '- ');
            }

            return templateLine;
        }

        //--------------------------------------------------------------
        // STRING FORMATTING METHODS
        //--------------------------------------------------------------

        String.prototype.allTrim = String.prototype.allTrim ||
            function () {
                return this.replace(/\s+/g, ' ')
                    .replace(/^\s+|\s+$/, '');
            };

        String.prototype.replaceAll = function (search, replacement) {
            var target = this;
            return target.replace(new RegExp(search, 'g'), replacement);
        };

        return this;
    };

    $.fn.paf.VERSION = "1.0.1";

    $.fn.paf.DEFAULTS = {
        maxRows: 100,
        addressFields: {
            Address1: "{Organisation} {Department} {POBox} {SubBuildingName} {BuildingName} {BuildingNumber} ",
            Address2: "{Thoroughfare} {ThoroughfareDependent}",
            Address3: "{Locality} {LocalityDependent} ",
            Town: "{Town} "
        },
        isLive: false
    };

})(jQuery);