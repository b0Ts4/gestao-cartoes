import { Component, OnInit } from '@angular/core';
import { DetalhesPagamentoService } from '../../shared/detalhes-pagamento.service';
import { NgForm } from '@angular/forms';
import { DetalhesPagamento } from '../../shared/detalhes-pagamento.model';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-detalhes-pagamento-form',
  templateUrl: './detalhes-pagamento-form.component.html',
  styles: [
  ]
})
export class DetalhesPagamentoFormComponent {

  constructor(public service: DetalhesPagamentoService, private toastr:ToastrService){
  }

  onSubmit(form:NgForm){
    this.service.formSubmitted = true
    if(form.valid){
      if(this.service.formData.detalhesCartaoId == 0)
        this.insertRecord(form)
      else
        this.updateRecord(form)
    }
  }
  
  insertRecord(form: NgForm){
    this.service.postDetalhesPagamento()
      .subscribe({
        next:res=>{
          this.service.list = res as DetalhesPagamento[]
          this.service.resetForm(form)
          this.toastr.success('Enviado com Sucesso', 'Formas de Pagamento')
          this.service.formSubmitted = false
        },
        error: err=> { console.log(err) }

      })}

      updateRecord(form: NgForm){
        this.service.putDetalhesPagamento()
          .subscribe({
            next:res=>{
            this.service.list = res as DetalhesPagamento[]
            this.service.resetForm(form)
            this.toastr.info('Atualizado com Sucesso', 'Formas de Pagamento')
            this.service.formSubmitted = false
        },
        error: err=> { console.log(err) }
      })
}}
