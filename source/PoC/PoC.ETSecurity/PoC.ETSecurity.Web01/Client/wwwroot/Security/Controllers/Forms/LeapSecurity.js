var authorizedUserName = window.AuthorizedUserName;
var authorizedPassword = window.AuthorizedPassword;

window.leapSecurity = (function () {
    function LeapSecurity(userName, userData) {
        this.userName = userName;
        this.groups = userData['groups'];
        this.roles = userData['roles'];
        this.items = userData['items'];
    }

    LeapSecurity.prototype.isInGroup = function (groupName) {
        var index = $.map(this.groups, function(g){return g.toLowerCase();}).indexOf(groupName.toLowerCase());
        return index >= 0;
    };

    LeapSecurity.prototype.isInRole = function (roleName) {
        var index = $.map(this.roles, function (r) { return r.Role.toLowerCase(); }).indexOf(roleName.toLowerCase());
        return index >= 0;
    };

    LeapSecurity.prototype.itemAccess = function (itemName, itemType) {
		var filtered = this.items.filter(function(r) {return r.ItemType.toLowerCase() === itemType.toLowerCase()});
        var index = $.map(filtered, function(r) {return r.ItemName.toLowerCase()}).indexOf(itemName.toLowerCase());
        return index >= 0 ? filtered[index].Access : 'N';
    };

    var leapSecurity = {
        load: function (baseUrl, userName) {
            var userData = {
                groups: null,
                roles: null,
                items: null,
            };
            jQuery.support.cors = true;
            jQuery.ajaxSetup({ async: false });
            $.ajax({
                url: baseUrl + "leap/security/groups/" + userName,
                type: "get",
                datatype: 'json',
                contentType: "application/json",
                pageSize: 32,
                success: function (data) {
                    userData.groups = data;
                },
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Authorization", "Basic " + btoa(window.AuthorizedUserName + ":" + window.AuthorizedPassword));
                }

            });

            $.ajax({
                url: baseUrl + "leap/security/roles/" + userName,
                type: "get",
                datatype: 'json',
                contentType: "application/json",
                pageSize: 32,
                success: function (data) {
                    userData.roles = data;
                },
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Authorization", "Basic " + btoa(window.AuthorizedUserName + ":" + window.AuthorizedPassword));
                }

            });

            $.ajax({
                url: baseUrl + "leap/security/items/" + userName,
                type: "get",
                datatype: 'json',
                contentType: "application/json",
                pageSize: 32,
                success: function (data) {
                    userData.items = data;
                },
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Authorization", "Basic " + btoa(window.AuthorizedUserName + ":" + window.AuthorizedPassword));
                }

            });

            return new LeapSecurity(userName, userData);
        }
    };
    return memoize(leapSecurity.load);
}());

/*
* memoize.js
* by @philogb and @addyosmani
* with further optimizations by @mathias
* and @DmitryBaranovsk
* perf tests: http://bit.ly/q3zpG3
* Released under an MIT license.
*/
function memoize( fn ) {
    return function () {
        var args = Array.prototype.slice.call(arguments),
            hash = "",
            i = args.length;
        currentArg = null;
        while (i--) {
            currentArg = args[i];
            hash += (currentArg === Object(currentArg)) ?
            JSON.stringify(currentArg) : currentArg;
            fn.memoize || (fn.memoize = {});
        }
        return (hash in fn.memoize) ? fn.memoize[hash] :
        fn.memoize[hash] = fn.apply(this, args);
    };
}

/* Common security screen calls for API layers */
var errMessage = "An error has occured during the operation. Contact IT Support if the issue persists."

//Return DataSource for Leap Roles.  Pass in gridName to configure for CRUD if needed
function getLeapRoles(gridName) {
    if (window.g_OdataUrl == '' || window.g_OdataUrl == 'undefined') {
        alert('O data url not set');
        return;
    }
    var sUrl = window.ODataSecurityUrl + 'LeapRole';

    var datasource = new kendo.data.DataSource({
        type: "odata",
        transport: {
            read: {
                url: sUrl,
                type: "get",
                dataType: "json",
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Authorization", "Basic " + btoa(window.authorizedUserName + ":" + window.authorizedPassword));
                }
            },
            update: {
                url: function (e) {
                    return sUrl + "(" + e.LEAP_ROLE_ID + ")";
                },
                data: function (e) {
                    e.LEAP_ROLE_UPDT_USRID = window.g_LoggedOnUser;
                    e.LEAP_ROLE_UPDT_DATE = new Date();
                },
                type: "PUT",
                complete: function (e, status) {
                    if (status == "success") {
                        $(gridName).data("kendoGrid").dataSource.read();
                    }
                },
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Authorization", "Basic " + btoa(window.authorizedUserName + ":" + window.authorizedPassword));
                }
              },
            create: {
                url: function (data) {
                    return sUrl;
                },
                type: "POST",
                contentType: "application/json; charset=utf-8",
                complete: function (e, status) {
                    if (status == "success") {
                        $(gridName).data("kendoGrid").dataSource.read();
                    }

                },
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Authorization", "Basic " + btoa(window.authorizedUserName + ":" + window.authorizedPassword));
                }
            },
            destroy: {
                url: function (e) {
                    return sUrl + "(" + e.LEAP_ROLE_ID + ")";
                },
                error: function (e) {

                    console.log("Error Type: " + e.type);
                    getOperationErrorMessage(e.xhr.responseText);
                    //refresh the grid to previous state
                    $(gridName).data("kendoGrid").cancelChanges();

                },
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Authorization", "Basic " + btoa(window.authorizedUserName + ":" + window.authorizedPassword));
                }
            },
        },
        error: function (e) {

            getOperationErrorMessage(e.xhr.responseText);
            //e.sender.options.error(new Error('Error deleting Item'));
            $(gridName).data("kendoGrid").cancelChanges();
        },
        schema: {
            data: "value",
            total: function (data) {
                return data['odata.count'];
            },
            model: {
                id: "LEAP_ROLE_ID",
                fields: {
                    LEAP_ROLE_ID: { type: "number", editable: false },
                    LEAP_ROLE_NAME: { type: "string", validation: {required: true}, nullable: false },
                    LEAP_ROLE_DESC: { type: "string", nullable: true },
                    LEAP_ROLE_ACCESS: { type: "string", validation: {required: true}, nullable: false },
                    LEAP_ROLE_UPDT_USRID: { type: "string", editable: false, defaultValue: window.g_LoggedOnUser },
                    LEAP_ROLE_UPDT_DATE: { type: "date", editable: false }
                }
            }
        },
        pageSize: 20,
        serverPaging: true,
        serverFiltering: true,
        serverSorting: true,
        sort: {
            field: "LEAP_ROLE_NAME",
            dir: "asc"
        }

    });
    return datasource;
}

//Return DataSource for Leap Items.  Pass in gridName to configure for CRUD if needed
function getLeapItems(gridName) {

    if (window.g_OdataUrl == '' || window.g_OdataUrl == 'undefined') {
        alert('O data url not set');
        return;
    }
    var sUrl = window.ODataSecurityUrl + 'LeapItem';

    var datasource = new kendo.data.DataSource({
        type: "odata",
        transport: {
            read: {
                url: sUrl,
                type: "get",
                dataType: "json",
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Authorization", "Basic " + btoa(window.authorizedUserName + ":" + window.authorizedPassword));
                }
            },
            update: {
                url: function (e) {

                    return sUrl + "(" + e.LEAP_ITEM_ID + ")";
                },
                data: function (e) {
                    e.LEAP_ITEM_UPDT_USRID = window.g_LoggedOnUser;
                    e.LEAP_ITEM_UPDT_DATE = new Date();
                },
                type: "PUT",
                complete: function (e, status) {
                    if (status == "success") {
                        $(gridName).data("kendoGrid").dataSource.read();
                    }
                },
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Authorization", "Basic " + btoa(window.authorizedUserName + ":" + window.authorizedPassword));
                },
            },
            create: {
                url: function (data) {

                    return sUrl;
                },
                type: "POST",
                complete: function (e, status) {
                    if (status == "success") {
                        $(gridName).data("kendoGrid").dataSource.read();
                    }
                    
                },
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Authorization", "Basic " + btoa(window.authorizedUserName + ":" + window.authorizedPassword));
                }
            },
            destroy: {
                url: function (e) {
                    return sUrl + "(" + e.LEAP_ITEM_ID + ")";
                },
                error: function (e) {

                    console.log("Error Type: " + e.type);
                    getOperationErrorMessage(e.xhr.responseText);
                    //refresh the grid to previous state
                    $(gridName).data("kendoGrid").cancelChanges();
                },
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Authorization", "Basic " + btoa(window.authorizedUserName + ":" + window.authorizedPassword));
                }

            },
        },
        error: function (e) {
            getOperationErrorMessage(e.xhr.responseText);
             $(gridName).data("kendoGrid").cancelChanges();
        },
        schema: {
            data: "value",
            total: function (data) {
                return data['odata.count'];
            },
            model: {
                id: "LEAP_ITEM_ID",
                fields: {
                    LEAP_ITEM_ID: { type: "number", editable: false },
                    LEAP_ITEM_TYPE_ID: { type: "number" },
                    LEAP_ITEM_NAME: { type: "string", validation: { required: true } },
                    LEAP_ITEM_DESC: { type: "string", nullable: true },
                    LEAP_ITEM_SOURCE_VALUE: { type: "string", nullable: true },
                    LEAP_ITEM_UPDT_USRID: { type: "string", editable: false, defaultValue: window.g_LoggedOnUser },
                    LEAP_ITEM_UPDT_DATE: { type: "date", editable: false }
                }
            }
        },
        pageSize: 20,
        serverPaging: true,
        serverFiltering: true,
        serverSorting: true,
        sort: {
            field: "LEAP_ITEM_NAME",
            dir: "asc"
        }

    });
    return datasource;
}

//Return DataSource for Leap Item Types.  Pass in gridName to configure for CRUD if needed
function getLeapItemTypes(gridName) {


    if (window.g_OdataUrl == '' || window.g_OdataUrl == 'undefined') {
        alert('O data url not set');
        return;
    }
    var sUrl = window.ODataSecurityUrl + 'LeapItemType';

    var datasource = new kendo.data.DataSource({
        type: "odata",
        transport: {
            read: {
                url: sUrl,
                type: "get",
                dataType: "json",
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Authorization", "Basic " + btoa(window.authorizedUserName + ":" + window.authorizedPassword));
                }
            },
            update: {
                url: function (e) {
                    return sUrl + "(" + e.LEAP_ITEM_TYPE_ID + ")";
                },
                data: function (e) {
                    e.LEAP_ITEM_TYPE_UPDT_USRID = window.g_LoggedOnUser;
                    e.LEAP_ITEM_TYPE_UPDT_DATE = new Date();
                },
                type: "PUT",
                complete: function (e, status) {
                    if (status == "success") {
                        $(gridName).data("kendoGrid").dataSource.read();
                    }

                },
                error: function (e) {
                    console.log("Error Type: " + e.type);
                    popupMessage(errMessage);
                },
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Authorization", "Basic " + btoa(window.authorizedUserName + ":" + window.authorizedPassword));
                }
            },
            create: {
                url: function (data) {
                    return sUrl;
                },
                type: "POST",
                contentType: "application/json; charset=utf-8",
                complete: function (e, status) {
                    if (status == "success") {
                        $(gridName).data("kendoGrid").dataSource.read();
                    }

                },
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Authorization", "Basic " + btoa(window.authorizedUserName + ":" + window.authorizedPassword));
                }
            },
            destroy: {
                url: function (e) {
                    return sUrl + "(" + e.LEAP_ITEM_TYPE_ID + ")";
                },
                error: function (e) {

                    console.log("Error Type: " + e.type);
                    getOperationErrorMessage(e.xhr.responseText);
                    //refresh the grid to previous state
                    $(gridName).data("kendoGrid").cancelChanges();

                },
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Authorization", "Basic " + btoa(window.authorizedUserName + ":" + window.authorizedPassword));
                }
            },
        },
        error: function (e) {
            getOperationErrorMessage(e.xhr.responseText);
            //e.sender.options.error(new Error('Error deleting Item'));
            $(gridName).data("kendoGrid").cancelChanges();
        },
        schema: {
            data: "value",
            total: function (data) {
                return data['odata.count'];
            },
            model: {
                id: "LEAP_ITEM_TYPE_ID",
                fields: {
                    LEAP_ITEM_TYPE_ID: { type: "number", editable: false },
                    LEAP_ITEM_TYPE_NAME: { type: "string", validation: { required: true } },
                    LEAP_ITEM_TYPE_DESC: { type: "string", nullable: true },
                    LEAP_ITEM_TYPE_UPDT_USRID: { type: "string", editable: false, defaultValue: window.g_LoggedOnUser },
                    LEAP_ITEM_TYPE_UPDT_DATE: { type: "date", editable: false }
                }
            }
        },
        pageSize: 20,
        serverPaging: true,
        serverFiltering: true,
        serverSorting: true,
        sort: {
            field: "LEAP_ITEM_TYPE_NAME",
            dir: "asc"
        }

    });
    return datasource;
}

//Return DataSource for Leap Security Groups.  Pass in gridName to configure for CRUD if needed
function getLeapSecurityGroups(gridName) {


    if (window.g_OdataUrl == '' || window.g_OdataUrl == 'undefined') {
        alert('O data url not set');
        return;
    }
    var sUrl = window.ODataSecurityUrl + 'LeapSecurityGroup';

    var datasource = new kendo.data.DataSource({
        type: "odata",
        transport: {
            read: {
                url: sUrl,
                type: "get",
                dataType: "json",
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Authorization", "Basic " + btoa(window.authorizedUserName + ":" + window.authorizedPassword));
                }
            },
            update: {
                url: function (e) {
                    return sUrl + "(" + e.SECURITY_GROUP_ID + ")";
                },
                data: function (e) {
                    e.SECURITY_GROUP_UPDT_USRID = window.g_LoggedOnUser;
                    e.SECURITY_GROUP_UPDT_DATE = new Date();
                },
                type: "PUT",
                complete: function (e, status) {
                    if (status == "success") {
                        $(gridName).data("kendoGrid").dataSource.read();
                    }
                },
                error: function (e) {
                    console.log("Error Type: " + e.type);
                    getOperationErrorMessage(e.xhr.responseText);
                },
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Authorization", "Basic " + btoa(window.authorizedUserName + ":" + window.authorizedPassword));
                }
            },
            create: {
                url: function (data) {
                    return sUrl;
                },
                type: "POST",
                complete: function (e,status) {
                    if (status == "success") {
                        $(gridName).data("kendoGrid").dataSource.read();
                    }

                },
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Authorization", "Basic " + btoa(window.authorizedUserName + ":" + window.authorizedPassword));
                }
            },
            destroy: {
                url: function (e) {
                    return sUrl + "(" + e.SECURITY_GROUP_ID + ")";
                },
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Authorization", "Basic " + btoa(window.authorizedUserName + ":" + window.authorizedPassword));
                }
            },
        },
        error: function (e) {
            getOperationErrorMessage(e.xhr.responseText);
            $(gridName).data("kendoGrid").cancelChanges();

        },
        schema: {
            data: "value",
            total: function (data) {
                return data['odata.count'];
            },
            model: {
                id: "SECURITY_GROUP_ID",
                fields: {
                    SECURITY_GROUP_ID: { type: "number", editable: false },
                    SECURITY_GROUP_NAME: { type: "string", validation: { required: true } },
                    SECURITY_GROUP_DESC: { type: "string", nullable: true },
                    SECURITY_GROUP_UPDT_USRID: { type: "string", editable: false, defaultValue: window.g_LoggedOnUser },
                    SECURITY_GROUP_UPDT_DATE: { type: "date", editable: false }
                }
            }
        },
        pageSize: 20,
        serverPaging: true,
        serverFiltering: true,
        serverSorting: true,
        sort: {
            field: "SECURITY_GROUP_NAME",
            dir: "asc"
        }

    });
    return datasource;
}

//Return DataSource for Leap Users.  Pass in gridName to configure for CRUD if needed
function getLeapUsers(gridName) {

    if (window.g_OdataUrl == '' || window.g_OdataUrl == 'undefined') {
        alert('O data url not set');
        return;
    }
    var sUrl = window.OdataUrl + 'Persons';

    var datasource = new kendo.data.DataSource({
        type: "odata",
        transport: {
            read: {
                url: sUrl,
                type: "get",
                dataType: "json",
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Authorization", "Basic " + btoa(window.authorizedUserName + ":" + window.authorizedPassword));
                }
            }
            //,update: {
            //    url: function (e) {
            //        return sUrl + "(" + e.LEAP_ITEM_ID + ")";
            //    },
            //    type: "PUT",
            //    complete: function (e) {
            //        $(gridName).data("kendoGrid").dataSource.read();
            //    },
            //    error: function (e) {
            //        console.log("Error Type: " + e.type);
            //    }
            //},
            //create: {
            //    url: function (data) {
            //        return sUrl;
            //    },
            //    type: "POST",
            //    complete: function (e) {
            //        $(gridName).data("kendoGrid").dataSource.read();
            //    }
            //},
            //destroy: {
            //    url: function (e) {
            //        return sUrl + "(" + e.LEAP_ITEM_ID + ")";
            //    }
            //},
              //parameterMap: function (data, type) {
              //  // Map data that will be sent to server
              //  if (type == "read") {
              //      if (data.filter) {
              //          if (data.filter.filters) {

              //              data.filter.filters
              //                  .filter(function (filter) {
              //                      return filter.field
              //                          && typeof filter.value === "string"
              //                  })
              //                  .forEach(function (filter) {
              //                      filter.field = "tolower(" + filter.field + ")";
              //                      filter.value = filter.value.toLowerCase();
              //                  });
              //          }
              //      }
              //      debugger;
              //      var newMap = kendo.data.transports.odata.parameterMap(data);
              //      delete newMap.$format;
              //      return newMap;
              //  }
              //  else {
              //      return JSON.stringify(data);
              //  }

        },
        error: function (e) {
            //display user friendly message here for data operations error
            popupMessage(errMessage);
        },
        schema: {
            data: "value",
            total: function (data) {
                return data['odata.count'];
            },
            model: {
                id: "PRSN_PERSON_ID",
                fields: {
                    PRSN_PERSON_ID: { type: "string", editable: false },
                    PRSN_NAME_FIRST: { type: "string" },
                    PRSN_NAME_LAST: { type: "string" },
                    PRSN_NAME_MID_I: { type: "string" },
                    PRSN_PHONE: { type: "string" },
                    PRSN_UPDT_USRID: { type: "string", editable: false, defaultValue: window.g_LoggedOnUser },
                    PRSN_UPDT_DATE: { type: "date", editable: false },
                    PRSN_FULL_NAME: { type: "string" },
                    PRSN_ACTIVE_YN: { type: "string" }

                }
            },
            parse: function (response) {
                var personArray = [], personObj;
                var values = response.value, n = values.length, i = 0;
                for (; i < n; i++) {
                    if (PersonActiveOrHaveGroups(values[i])) {
                        personObj = values[i];
                        personObj.PRSN_FULL_NAME = personObj.PRSN_NAME_LAST.trim() + ", " + personObj.PRSN_NAME_FIRST.trim() + " (" + personObj.PRSN_PERSON_ID.trim() + ")";
                        personArray.push(personObj);
                    }
                }
                response.value = personArray;
                return response;
            }
        },

        pageSize: 20,
        serverPaging: true,
        serverFiltering: false,
        serverSorting: true,
        sort: {
            field: "PRSN_NAME_LAST",
            dir: "asc"
        }

    });
    return datasource;
}

function PersonActiveOrHaveGroups(dataRow) {
    if (dataRow.PRSN_ACTIVE_YN === 'N') {
        var association = personGroupAssociationData.value.filter(function (data) { return data.PRSN_PERSON_ID === dataRow.PRSN_PERSON_ID; });
        if (association && !association.length) {
            return false;
        }
    }
    return true;
}

function getItemTypeName(itemTypeID, dataSource) {
    var itemTypeName, itemTypeDS;

    //itemTypeDS = $(gridName).data("kendoGrid").dataSource;

    $.each(dataSource.data(), function (index, item) {

        if (item.LEAP_ITEM_TYPE_ID == itemTypeID) {
            itemTypeName = item.LEAP_ITEM_TYPE_NAME;
        }
    });
    return itemTypeName;
}

function getItemName(itemID, dataSource) {
    var itemName;

    $.each(dataSource.data(), function (index, item) {

        if (item.LEAP_ITEM_ID == itemID) {
            itemName = item.LEAP_ITEM_NAME;
        }
    });
    return itemName;
}

function getRoleName(roleID, dataSource) {
    var roleName;

    $.each(dataSource.data(), function (index, item) {

        if (item.LEAP_ROLE_ID == roleID) {
            roleName = item.LEAP_ROLE_NAME;
        }
    });
    return roleName;
}

function resizeSecurityDropdown(e) {
    var $dropDown = $(e.sender.element),
               dataWidth = $dropDown.data("kendoDropDownList").list.width(),
               listWidth = dataWidth + 20,
               containerWidth = listWidth + 6;

    // Set widths to the new values
    $dropDown.data("kendoDropDownList").list.width(listWidth);
    $dropDown.closest(".k-widget").width(containerWidth);

}

function getUserFullName(userID, dataSource) {
    var fullUserName = " ";

    $.each(dataSource.data(), function (index, item) {

        if (item.PRSN_PERSON_ID == userID) {
            fullUserName = item.PRSN_NAME_LAST + "," + item.PRSN_NAME_FIRST;
        }
    });
    return fullUserName;
}

function getSecurityGroupName(groupID, dataSource) {
    var secGroupName = " ";

    $.each(dataSource.data(), function (index, item) {

        if (item.SECURITY_GROUP_ID == groupID) {
            secGroupName = item.SECURITY_GROUP_NAME;
        }
    });
    return secGroupName;
}

function getOperationErrorMessage(msg) {

    if (msg.indexOf('duplicate') > 0) {
        popupMessage("An entry with this name already exists");
    }
    else if (msg.toLowerCase().indexOf('delete') > 0)
    {
        popupMessage("Cannot delete this entry as it still has associated entries");
    }
    else {
        //display user friendly message here for data operations error
        popupMessage(errMessage);
    }

}


