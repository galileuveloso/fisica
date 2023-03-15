import { Injectable } from '@angular/core';

declare var $: any;

@Injectable({
  providedIn: 'root'
})
export class NotificacoesService {

  constructor() { }

  mostrarErros(mensagens: string[]) {
    for (var i = 0; i < mensagens.length; i++) {
      this.mostrarErro(mensagens[i]);
    }
  }

  mostrarErro(mensagem: string) {
    this.showNotification('top', 'right', 'danger', mensagem);
  }

  mostrarSucesso(mensagem: string) {
    this.showNotification('top', 'right', 'success', mensagem);
  }

  mostrarInformacao(mensagem: string) {
    this.showNotification('top', 'right', 'info', mensagem);
  }

  mostrarAviso(mensagem: string) {
    this.showNotification('top', 'right', 'warning', mensagem);
  }

  private showNotification(from: string, align: string, type: string, message: string) {
    $.notify({
      icon: "notifications",
      message: message
    }, {
      type: type,
      timer: 2000,
      placement: {
        from: from,
        align: align
      },
      template: '<div data-notify="container" class="col-xl-4 col-lg-4 col-11 col-sm-4 col-md-4 alert alert-{0} alert-with-icon" role="alert">' +
        '<button mat-button  type="button" aria-hidden="true" class="close mat-button" data-notify="dismiss">  <i class="material-icons">close</i></button>' +
        '<i class="material-icons" data-notify="icon">notifications</i> ' +
        '<span data-notify="title">{1}</span> ' +
        '<span data-notify="message">{2}</span>' +
        '<div class="progress" data-notify="progressbar">' +
        '<div class="progress-bar progress-bar-{0}" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%;"></div>' +
        '</div>' +
        '<a href="{3}" target="{4}" data-notify="url"></a>' +
        '</div>'
    });
  }
}
