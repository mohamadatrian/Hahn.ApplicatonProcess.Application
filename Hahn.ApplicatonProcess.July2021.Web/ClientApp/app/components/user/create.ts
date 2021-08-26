import { HttpClient } from 'aurelia-fetch-client';
import { inject, observable } from 'aurelia-framework';
import { Router } from "aurelia-router";
import { ValidationRules, ValidationController, ValidationControllerFactory } from "aurelia-validation";
import { DialogService } from 'aurelia-dialog';
import { BootstrapFormRenderer } from '../app/BootstrapFormRenderer';
import { PromptDialog } from '../../dialog/promptDialog';

@inject(Router, HttpClient, ValidationControllerFactory, DialogService)
export class Create {
    @observable user: User;
    http: HttpClient;
    router: Router;
    dialogService: DialogService;
    controller: ValidationController;


    constructor(router: Router,
        http: HttpClient,
        controllerFactory: ValidationControllerFactory,
        dialogService: DialogService) {
        this.router = router;
        this.http = http;
        this.dialogService = dialogService;
        this.controller = controllerFactory.createForCurrentScope();
        this.controller.addRenderer(new BootstrapFormRenderer());

        this.setDefaults();
    }

    userChanged() {
        if (this.user) {
            ValidationRules
                .ensure('firstName').required().minLength(3)
                .ensure("lastName").required().minLength(3)
                .ensure("email").required().email()
                .on(this.user);

            ValidationRules
                .ensure("street").required()
                .ensure("postalCode").required()
                .ensure("houseNo").required()
                .on(this.user.address);
        }
    }

    setDefaults() {
        this.user = {
            id: 0,
            firstName: '',
            lastName: '',
            email: '',
            age: 0,
            address: {
                houseNo: '',
                postalCode: '',
                street: '',
            },
            assets: null
        };
    }

    get canReset() {
        return this.user && (
            this.user.firstName ||
            this.user.lastName ||
            this.user.email ||
            this.user.age > 0 ||
            this.user.address.houseNo ||
            this.user.address.postalCode ||
            this.user.address.street);
    }

    reset() {
        if (this.canReset) {
            this.dialogService.open({ viewModel: PromptDialog, model: 'Do you want to reset form?', lock: false }).whenClosed(response => {
                if (!response.wasCancelled) {
                    this.setDefaults();
                }
            });
        }
    }

    save() {
        this.controller.validate()
            .then(v => {
                if (v.valid) {
                    this.dialogService.open({ viewModel: PromptDialog, model: 'Do you want to proceed?', lock: false }).whenClosed(dialogResponse => {
                        if (!dialogResponse.wasCancelled) {
                            this.http.fetch(`user/`, {
                                method: 'POST',
                                headers: {
                                    'Content-Type': 'application/json',
                                },
                                body: JSON.stringify(this.user)
                            }).then(response => {
                                if (response.ok) {
                                    let url = this.router.generate("userlist");
                                    this.router.navigate(url)
                                }
                            })
                        }
                    });
                }
            });
    }
}
