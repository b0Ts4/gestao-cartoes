import { Component,OnInit } from '@angular/core';
import { DetalhesPagamentoService } from '../shared/detalhes-pagamento.service';
import { DetalhesPagamento } from '../shared/detalhes-pagamento.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-detalhes-pagamento',
  templateUrl: './detalhes-pagamento.component.html',
  styles: ``
})
export class DetalhesPagamentoComponent implements OnInit {

  constructor(public service: DetalhesPagamentoService, private toastr:ToastrService){

  }
  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord:DetalhesPagamento){
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id:number){
    if(confirm('Tem certeza que deseja deletar esse cartão?'))
    this.service.deleteDetalhesPagamento(id)
    .subscribe({
      next:res=>{
      this.service.list = res as DetalhesPagamento[]
      this.toastr.error('Apagado com Sucesso', 'Formas de Pagamento')
      },
      error: err=> { console.log(err) }
    })
  }
}
