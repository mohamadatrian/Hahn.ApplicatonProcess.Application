import { inject } from 'aurelia-framework';
import { DialogController } from 'aurelia-dialog';

@inject(DialogController)

export class Error {
    response: Response;
    controller: DialogController;
    constructor(controller: DialogController) {
        this.controller = controller;
        controller.settings.centerHorizontalOnly = true;
    }
    activate(response: Response) {
        this.response = response;
    }
}