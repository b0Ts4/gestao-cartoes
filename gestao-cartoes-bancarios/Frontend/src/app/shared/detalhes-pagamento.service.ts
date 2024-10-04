import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from '../../environments/environment';
import { DetalhesPagamento } from './detalhes-pagamento.model';
import { NgFor } from '@angular/common';
import { NgForm } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class DetalhesPagamentoService {

  url:string = environment.apiBaseUrl + '/DetalhesCartao';
  list:DetalhesPagamento[] = [];
  formData: DetalhesPagamento = new DetalhesPagamento();
  formSubmitted: boolean = false;

  constructor(private http: HttpClient) { }

  refreshList(){
    this.http.get(this.url)
    .subscribe({
      next: res=>{ 
        this.list= res as DetalhesPagamento[]
       },
      error: err=>{ console.log(err) }
    })
  }

  postDetalhesPagamento(){
    return this.http.post(this.url, this.formData)
  }

  putDetalhesPagamento(){
    return this.http.put(this.url + '/' + this.formData.detalhesCartaoId, this.formData)
  }

  deleteDetalhesPagamento(id:number){
    return this.http.delete(this.url + '/' + id) 
  }

  resetForm(form:NgForm){
      form.form.reset()
      this.formData= new DetalhesPagamento()
  }
}
