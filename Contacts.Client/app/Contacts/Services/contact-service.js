angular
    .module("common.services")
    .factory("contactService", function ($resource, appSettings) {
        return $resource(appSettings.serverPath + "contacts", {
            query: {
                method: 'GET'
            },
            save: { method: 'POST' },
        });
    });