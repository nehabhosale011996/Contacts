angular
    .module("common.services")
    .factory("editContact", function ($resource, appSettings) {
        return $resource(appSettings.serverPath + "contacts/:contactid", { contactid: '@contactid' }, {
                update: { method: 'PUT' }
            });
    });
