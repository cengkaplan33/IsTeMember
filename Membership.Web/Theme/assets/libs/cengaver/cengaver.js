/** 
 * CENGAVER FORM HELPERS
 * 
**/

(function ($) {

    
    $.handleError = function (s, xhr, status, e) {
        // If a local callback was specified, fire it
        if (s.error) {
            s.error.call(s.context, xhr, status, e);
        }

        // Fire the global callback
        if (s.global) {
            jQuery.triggerGlobal(s, "ajaxError", [xhr, s, e]);
        }
    };

    $.httpData = function (xhr, type, s) {
        var ct = xhr.getResponseHeader("content-type") || "",
            xml = type === "xml" || !type && ct.indexOf("xml") >= 0,
            data = xml ? xhr.responseXML : xhr.responseText;

        if (xml && data.documentElement.nodeName === "parsererror") {
            jQuery.error("parsererror");
        }

        // Allow a pre-filtering function to sanitize the response
        // s is checked to keep backwards compatibility
        if (s && s.dataFilter) {
            data = s.dataFilter(data, type);
        }

        // The filter can actually parse the response
        if (typeof data === "string") {
            // Get the JavaScript object, if JSON is used.
            if (type === "json" || !type && ct.indexOf("json") >= 0) {
                data = jQuery.parseJSON(data);

                // If the type is "script", eval it in global context
            } else if (type === "script" || !type && ct.indexOf("javascript") >= 0) {
                jQuery.globalEval(data);
            }
        }

        return data;
    };

    $.cengaver = $.cengaver || {};

    $.cengaver = $.extend($.cengaver, {

        callService: function (options) {
            options = $.extend({
                dataType: 'json',
                contentType: 'application/json',
                type: 'POST',
                cache: false,
                blockUI: true,
                url:  options.service,
                data: $.toJSON(options.request),
                success: function (response, status) {
                    try {
                        try {
                            if (!response.Error) {
                                if (options.onSuccess)
                                    options.onSuccess(response);
                            }
                            else if (options.onError)
                                options.onError(response);
                            else
                                $.cengaver.serviceError(response.Error);
                        }
                        finally {
                            if (options.blockUI)
                                $.cengaver.BlockUndo();

                            if (options.onCleanup)
                                options.onCleanup();
                        }
                    } catch (e) {
                        var stacktrace;
                        if (e.stack)
                            stacktrace = e.stack;
                        else try {
                            throw "!";
                        } catch (e) {
                            stacktrace = e.stack || e.stacktrace || "";
                        }
                        window.console && window.console.log(stacktrace || e.message || e);
                    }
                },
                error: function (xhr, status, e) {
                    try {
                        try {
                            if (xhr.status == 403) {
                                var l = null;
                                try { l = xhr.getResponseHeader('Location'); } catch (e) { l = null; }
                                if (l) {
                                    top.location.href = l;
                                    return;
                                }
                            }

                            var html = $.httpData(xhr);

                            alert(html);
                            //if ($.fn.dialog && $.pi.iframeDialog) {
                            //    $.pi.iframeDialog({ html: html });
                            //}
                            //else
                            //    $.pi.alert(html);

                        } finally {
                            if (options.blockUI)
                                $.cengaver.BlockUndo();

                            if (options.onCleanup)
                                options.onCleanup();
                        }
                    } catch (e) {
                        var stacktrace;
                        if (e.stack)
                            stacktrace = e.stack;
                        else try {
                            throw "!";
                        } catch (e) {
                            stacktrace = e.stack || e.stacktrace || "";
                        }
                        window.console && window.console.log(stacktrace || e.message || e);
                    }
                }

            }, options);

            if (options.blockUI)
                $.cengaver.BlockUI();

            return $.ajax(options);
        },

        postToService: function (options) {
            var form = $('<form/>')
            .attr('method', 'POST')
            .attr('action', Q.ResolveUrl('~/services/' + options.service))
            .appendTo(document.body);

            if (options.target)
                form.attr('target', options.target);

            var div = $('<div/>').appendTo(form);

            $('<input/>').attr('type', 'hidden').attr('name', 'request').val($.toJSON(options.request)).appendTo(div);
            $('<input/>').attr('type', 'submit').appendTo(div);

            form.submit();
            window.setTimeout(function () { form.remove(); }, 0);
        },

        serviceError: function (error) {
            alert(error && (error.Message || error.Code))
            //$.pi.alert(error && (error.Message || error.Code));
        },

        BlockUI: function(options) {
            options = $.extend({ baseZ: 2000, message: '', overlayCSS: { opacity: '0.4', zIndex: 2000, cursor: 'wait' }, fadeOut: 0 }, options);
            if ((options).useTimeout) {
                window.setTimeout(function() {
                    ($.blockUI(options));
                }, 0);
            }
            else {
                ($.blockUI(options));
            }
        },

        BlockUndo: function() {
            ($.unblockUI({fadeOut: 0}));
        },



    });
})(jQuery);