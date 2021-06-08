angular
    .module("Contacts")
    .controller("contactCtrl", function ($routeParams, contactService, editContact, $scope, $compile, $http, $timeout) {

        var hot;
        $scope.editcontact = new editContact();

        $scope.data = contactService.query(function () {
            var container = document.getElementById('example1');
            Contacts = _.orderBy($scope.data.Contacts, [contact => contact.firstName.toLowerCase()], ['asc']);

            hot = new Handsontable(container, {
                data: Contacts,
                colHeaders: ['firstName', 'lastName', 'email', 'phoneNumber', 'status'],
                filters: true,
                columnSorting: true,
                colWidths: [100, 100, 100, 100, 100],
                currentRowClassName: 'currentRow',
                readOnly: true,
                licenseKey: 'non-commercial-and-evaluation',
                columns: [
                    {
                        data: 'firstName',

                    },
                    {
                        data: 'lastName',

                    },
                    {
                        data: 'email',

                    },
                    {
                        data: 'phoneNumber',

                    },
                    {
                        data: 'status',
                    },
                    {
                        data: 'Edit',
                        renderer: EditRenderer,
                        readonly: true
                    }
                ],

                afterSelection: function (row) {
                    $scope.ContactId = this.getSourceDataAtRow(row).Id;

                    $scope.rowdata = this.getSourceDataAtRow(row);

                    $scope.editcontact.id = this.getSourceDataAtRow(row).Id;
                    $scope.editcontact.firstName = this.getSourceDataAtRow(row).firstName;
                    $scope.editcontact.lastName = this.getSourceDataAtRow(row).lastName;
                    $scope.editcontact.email = this.getSourceDataAtRow(row).email;
                    $scope.editcontact.phoneNumber = this.getSourceDataAtRow(row).phoneNumber;
                    $scope.editcontact.status = this.getSourceDataAtRow(row).status;
                    $scope.$digest();
                }
            });
            function EditRenderer(instance, td, row, col, prop, value, cellProperties) {
                angular.element(td).empty();
                td.appendChild($compile("<button type='button' class='btn btn-primary btn-sm'  data-toggle='modal' data-target='#editContact' ><span class='fa fa-edit' aria-hidden='true'></span></button >")($scope)[0]);
            }
        });


        $scope.addContact = function (AddForm) {
            contactService.save($scope.contact, function (data) {
                if (data.ContactId != -1) {
                    $scope.contact.id = data.ContactId;
                    $scope.contact = {
                        id: $scope.contact.id,
                        firstName: $scope.contact.firstName,
                        lastName: $scope.contact.lastName,
                        email: $scope.contact.email,
                        phoneNumber: $scope.contact.phoneNumber,
                        tatus: $scope.contact.status,

                    }
                    alert("Contact Added");

                    Contacts.push($scope.contact);
                    Contacts = _.orderBy(Contacts, [contact => contact.firstName.toLowerCase()], ['asc']);
                    hot.loadData(Contacts);

                    var row = _.findIndex(Contacts, function (i) { return i.id == $scope.contact.id; });

                    $timeout(function () {
                        hot.selectRows(row);
                    }, 100);
                }
                else {
                    alert("Contact should be unique");
                }
                $scope.contact = {};
            }, function (error) {
                console.log(error.data.ExceptionMessage);
            });
        };

        $scope.reset = function () {
            $scope.contact = {
                firstName: "",
                lastName: "",
                email: "",
                phoneNumber: "",
                status: ""
            }
        };

        $scope.edit = function () {
            editContact.update({ contactid: $scope.ContactId }, $scope.editcontact, function (data) {
                console.log(data);
                if (data.status == "SUCCESS") {
                    $scope.rowdata.firstName = $scope.editcontact.firstName;
                    $scope.rowdata.lastName = $scope.editcontact.lastName;
                    $scope.rowdata.email = $scope.editcontact.email;
                    $scope.rowdata.phoneNumber = $scope.editcontact.phoneNumber;
                    $scope.rowdata.status = $scope.editcontact.status;
                    Contacts = _.orderBy(Contacts, [contact => contact.Summary.toLowerCase()], ['asc']);
                    hot.loadData(Contacts);

                    alert("Contact Updated");
                    var row = _.findIndex(Contacts, function (i) { return i.id == $scope.rowdata.id; });

                    $timeout(function () {

                        hot.selectRows(row);
                    }, 100);
                }
                else {
                    alert("Contact not updated");
                }
            });
        };
    });





