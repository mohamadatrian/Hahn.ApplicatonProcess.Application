import { DialogService } from 'aurelia-dialog';
import { HttpClient } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';
import { PromptDialog } from '../../dialog/promptDialog';

@inject(HttpClient, DialogService)
export class List {
    public users: User[];
    http: HttpClient;
    dialogService: DialogService;
    constructor(http: HttpClient, dialogService: DialogService) {
        this.http = http;
        this.getAll();
        this.users = [];
        this.dialogService = dialogService;
    }
    getAll() {
        this.http.fetch('user/')
            .then(result => result.json() as Promise<User[]>)
            .then(data => {
                this.users = data;
            });
    }

    delete(id: number) {
        this.dialogService.open({ viewModel: PromptDialog, model: 'Do you want to proceed?', lock: false }).whenClosed(dialogResponse => {
            if (!dialogResponse.wasCancelled) {
                this.http.fetch(`user/${id}`, {
                    method: 'DELETE'
                }).then(response => {
                    this.getAll();
                });
            }
        });
    }
}
