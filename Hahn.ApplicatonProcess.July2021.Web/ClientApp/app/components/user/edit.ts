import { HttpClient } from 'aurelia-fetch-client';
import { inject, observable } from 'aurelia-framework';
import { Router } from "aurelia-router";
import { ValidationRules, ValidationController, ValidationControllerFactory } from "aurelia-validation";
import { DialogService } from 'aurelia-dialog';
import { BootstrapFormRenderer } from '../app/BootstrapFormRenderer';
import { Prompt } from '../../dialog/Prompt';

@inject(Router, HttpClient, ValidationControllerFactory, DialogService)
export class Edit {
    @observable user: User | undefined;
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
    }

    activate(params: any) {
        this.http.fetch(`user/${params.id}`)
            .then(result => result.json() as Promise<User>)
            .then(data => {
                this.user = data;
            });
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

    reset() {
        if (this.canReset) {
            this.dialogService.open({ viewModel: Prompt, model: 'Do you want to reset form?', lock: false }).whenClosed(response => {
                if (!response.wasCancelled && this.user) {
                    this.user.firstName = '';
                    this.user.lastName = '';
                    this.user.email = '';
                    this.user.age = 0;
                    this.user.address.houseNo = '';
                    this.user.address.postalCode = '';
                    this.user.address.street = '';
                }
            });
        }
    }

    save() {
        this.controller.validate()
            .then(v => {
                if (v.valid) {
                    this.dialogService.open({ viewModel: Prompt, model: 'Do you want to proceed?', lock: false }).whenClosed(response => {
                        if (!response.wasCancelled) {
                            this.http.fetch(`user/`, {
                                method: 'PUT',
                                headers: {
                                    'Content-Type': 'application/json',
                                },
                                body: JSON.stringify(this.user)
                            }).then(response => {
                                if (response.ok) {
                                    let url = this.router.generate("userlist");
                                    this.router.navigate(url)
                                }
                            });
                        }
                    });
                }
            });
    }
}
