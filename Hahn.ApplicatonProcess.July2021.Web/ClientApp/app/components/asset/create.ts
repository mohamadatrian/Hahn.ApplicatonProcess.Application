import { HttpClient } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';
import { Router } from "aurelia-router";
import { ValidationRules, ValidationController, ValidationControllerFactory } from "aurelia-validation";
import { DialogService } from 'aurelia-dialog';
import { Prompt } from '../../dialog/Prompt';
import { BootstrapFormRenderer } from '../app/BootstrapFormRenderer';

@inject(Router, HttpClient, ValidationControllerFactory, DialogService)
export class Create {
    asset: CreateAsset = {
        id: '',
        symbol: '',
        name: '',
        userId: 0
    };

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
        this.asset.userId = params.id;

        ValidationRules
            .ensure('id').required()
            .ensure('symbol').required()
            .ensure('name').required()
            .on(this.asset);
    }

    get canReset() {
        return this.asset && (
            this.asset.id ||
            this.asset.name ||
            this.asset.symbol);
    }

    reset() {
        if (this.canReset) {
            this.dialogService.open({ viewModel: Prompt, model: 'Do you want to reset form?', lock: false }).whenClosed(response => {
                if (!response.wasCancelled && this.asset) {
                    this.asset.symbol = '';
                    this.asset.name = '';
                    this.asset.id = '';
                }
            });
        }
    }

    save() {
        this.controller.validate()
            .then(v => {
                if (v.valid) {
                    this.dialogService.open({ viewModel: Prompt, model: 'Do you want to proceed?', lock: false }).whenClosed(response => {
                        if (!response.wasCancelled && this.asset) {
                            this.http.fetch(`asset`, {
                                method: 'POST',
                                headers: {
                                    'Content-Type': 'application/json',
                                },
                                body: JSON.stringify(this.asset)
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
