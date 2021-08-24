import { inject } from 'aurelia-framework';
import { DialogController } from 'aurelia-dialog';

@inject(DialogController)

export class Prompt {
    message: string;
    controller: DialogController;
    answer: null;
    constructor(controller: DialogController) {
        this.controller = controller;
        this.answer = null;

        controller.settings.centerHorizontalOnly = true;
    }
    activate(message: string) {
        this.message = message;
    }
}