﻿/// <reference path="jquery-1.8.1.js" />
(function ($) {

    function fileFromPath(file) {
        return file.replace(/.*(\/|\\)/, "");
    }

    function getExt(file) {
        return (-1 !== file.indexOf('.')) ? file.replace(/.*[.]/, '') : '';
    }

    var getUID = (function () {
        var id = 0;
        return function () {
            return '_JQuery_AjaxUpload_' + id++;
        };
    })();

    var AjaxUpload = function (element, options) {
        var self = this;
        var $element = $(element);

        var $container = $('<div style="background: #f00; overflow: hidden; display: none; opacity: 0; filter: alpha(opacity=0);"></div>')
            .insertAfter($element);
        var $inputParent = $('<div style="direction: rtl; float: left; width: auto; opacity: 0; filter: alpha(opacity=0);"></div>').appendTo($container);

        self.setParams = function (parmas) {
            options.parmas = parmas;
        };

        self._createInput = function () {
            var $input = $('<input type="file" style="margin: -10px auto auto -10px; font-size: 480px; font-family: sans-serif; cursor: pointer;" name="' + (options.name || getUID()) + '" />')
            .appendTo($inputParent);
            $input.change(function () {
                var file = fileFromPath(this.value);
                var ext = getExt(file);
                if (!ext) {
                    alert('不支持无后缀文件上传');
                    return false;
                }
                if (options.allowedExtensions && $.inArray(ext.toLowerCase(), options.allowedExtensions) == -1) {
                    alert('仅支持后缀为“ ' + options.allowedExtensions.join(' | ') + ' ”的文件上传');
                    return false;
                }

                try {
                    if (false === options.submit.call(self, file)) {
                        return false;
                    }
                }
                catch (ex) {

                }

                var id = getUID();
                var toDeleteFlag = false
                var $iframe = $('<iframe src="javascript:false;" name="' + id + '" style="display: none;" />').appendTo(document.body);
                $iframe.load(function () {
                    var iframe = this;
                    if (iframe.src == "javascript:'%3Chtml%3E%3C/html%3E';" || iframe.src == "javascript:'<html></html>';") {
                        if (toDeleteFlag) {
                            setTimeout(function () {
                                $iframe.remove();
                                $form.remove();
                                self._createInput();
                            }, 0);
                        }
                        return;
                    }
                    var doc = iframe.contentDocument ? iframe.contentDocument : window.frames[id].document;
                    if (doc.readyState && doc.readyState != 'complete') {
                        return;
                    }
                    if (doc.body && doc.body.innerHTML == "false") {
                        return;
                    }
                    var response;

                    if (doc.XMLDocument) {
                        response = doc.XMLDocument;
                    } else if (doc.body) {
                        response = doc.body.innerHTML;

                        if (options.responseType && options.responseType.toLowerCase() == 'json') {
                            if (doc.body.firstChild && doc.body.firstChild.nodeName.toUpperCase() == 'PRE') {
                                try {
                                    doc.normalize();
                                }
                                catch (ex) {
                                }
                                response = doc.body.firstChild.firstChild.nodeValue;
                            }

                            if (response) {
                                response = eval("(" + response + ")");
                            } else {
                                response = {};
                            }
                        }
                    } else {
                        response = doc;
                    }

                    try {
                        options.complete.call(self, file, response);
                    }
                    catch (ex) {
                    }

                    toDeleteFlag = true;
                    iframe.src = "javascript:'<html></html>';";
                });

                var $form = $('<form method="post" enctype="multipart/form-data" style="display: none;"></form>').appendTo(document.body);
                $form.attr('target', id);
                $form.attr('action', options.action);

                if (options.params) {
                    for (var name in options.params) {
                        $('<input type="hidden" />').attr('name', name)
                        .appendTo($form)
                        .val(options.params[name]);
                    }
                }

                $input.remove().attr('name', options.name).appendTo($form);
                $form.submit();
            });
        };

        self._createUploadArea = function () {
            var cssNames = ['float', 'border', 'margin', 'padding', 'position', 'display', 'width', 'height', 'font', 'border-radius', '-webkit-border-radius', '-moz-border-radius'];
            $.each(cssNames, function (i) {
                var name = cssNames[i];
                $container.css(name, $element.css(name));
            });
            var elementPos = $element.position();
            var containerPos = $container.position();
            var ml = parseInt($container.css('margin-left'));
            if (isNaN(ml)) ml = 0;
            var mt = parseInt($container.css('margin-top'));
            if (isNaN(mt)) mt = 0;
            $container.css('margin-left', ml + elementPos.left - containerPos.left);
            $container.css('margin-top', mt + elementPos.top - containerPos.top);
        };

        $element.mouseenter(function () {
            if (!$element.data('uploader-created')) {
                $element.data('uploader-created', true);
                self._createUploadArea();
                self._createInput();
            }
        });

    };

    var defaults = {
        action: '/file-upload',
        responseType: 'json',
        allowedExtensions: ['jpg', 'bmp', 'png', 'gif'],
        params: {},
        name: null,
        submit: function (fileName) { },
        complete: function (fileName, result) { }
    };

    $.fn.ajaxUpload = function (options) {
        var callArgs = arguments;
        this.each(function () {
            if (!this.ajaxUpload) {
                var uploader = new AjaxUpload(this, $.extend({}, defaults, options || {}));
                this.ajaxUpload = uploader;
            }
            else {
                if (typeof (options) == 'string') {
                    if (options == 'setParams') this.ajaxUpload.setParams(callArgs[1]);
                }
            }
        });
        return this;
    };

})(jQuery);