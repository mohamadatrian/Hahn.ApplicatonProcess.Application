import { inject } from 'aurelia-framework';
import { DialogController } from 'aurelia-dialog';

@inject(DialogController)
export class ErrorDialog {
    error: ServerError;
    controller: DialogController;
    constructor(controller: DialogController) {
        this.controller = controller;
        controller.settings.centerHorizontalOnly = true;
    }
    activate(error: ServerError) {
        this.error = error;
    }
}