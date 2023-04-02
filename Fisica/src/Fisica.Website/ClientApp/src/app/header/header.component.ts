import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit  {
  imagem: string= "";
  resumoTopico: string = "";
  resumoTitulo: string = "";
  telaInicial: boolean = true;

  constructor () {
    this.imagem = "../../assets/imagens/header/home.png";
    this.resumoTitulo = "Home";
    this.resumoTopico = "Aqui é a página inicial, abaixo temos um resumo sobre a Física e" 
                        + "as ultimas postagens. Na direita temos as principais seções do site.";
  }

  ngOnInit(): void {}

  mudarCabecalho(cabecalho: boolean) {
    this.telaInicial= cabecalho;
  }

  mudaFoto (foto: string)
	{
		switch(foto) {
      case "0":
        this.imagem = "../../../assets/imagens/header/home.png";
        this.resumoTitulo = "Home";
        this.resumoTopico = "Aqui é a página inicial, abaixo temos um resumo sobre a Física e" 
                            + "as ultimas postagens. Na direita temos as principais seções do site.";
        break;
      case "1":
        this.imagem = "../../../assets/imagens/header/mecanica.png";
        this.resumoTitulo = "Mecânica";
        this.resumoTopico = "O que é a velocidade? Podemos prever o movimento dos planetas?" 
                            + " Essas e outras perguntas serão respondidas aqui.";
        break;
      case "2":
        this.imagem = "../../../assets/imagens/header/termodinamica.png";
        this.resumoTitulo = "Termodinâmica";
        this.resumoTopico = "Aqui descobriremos o que é o calor, a diferença entre calor" 
                            + " e temperatura e muitos outros conceitos.";
        break;
      case "3":
        this.imagem = "../../../assets/imagens/header/ondulatoria.png";
        this.resumoTitulo = "Ondulatória";
        this.resumoTopico = "Vamos compreender juntos como o som se propaga e porquê não existe som no espaço.";
        break;
      case "4":
        this.imagem = "../../../assets/imagens/header/eletromagnetismo.png";
        this.resumoTitulo = "Eletormagnetismo";
        this.resumoTopico = "O que é corrente alternada? Encostar em 20 mil volts é seguro?" 
                            + " Vamos juntos compreender as leis do eletromagnetismo.";
        break;
      case "5":
        this.imagem = "../../../assets/imagens/header/fisicamoderna.png";
        this.resumoTitulo = "Física moderna";
        this.resumoTopico = "Podemos viajar mais rápido que a luz? Qual o tamanho do átomo?" 
                            + " Nesse tópico vamos movimento relativístico e as pequenas partículas";
        break;
      case "6":
        this.imagem = "../../../assets/imagens/header/matematica.png";
        this.resumoTitulo = "Matemática";
        this.resumoTopico = "Para descrevermos a natureza precisamos compreender sua linguagem." 
                            + " Essa linguagem é a matemática. Aqui discutiremos os principais "
                            + "conceitos matemáticos que nos ajudaram a compreender os fenômenos físicos.";
        break;
      case "7":
        this.imagem = "../../../assets/imagens/header/especiais.png";
        this.resumoTitulo = "Especiais";
        this.resumoTopico = "Aqui vamos trabalhar alguns tópicos especiais como: história da física," 
                            + " cosmologia, experimentos, etc.";
        break;
      case "8":
        this.imagem = "../../../assets/imagens/header/vestibular.png";
        this.resumoTitulo = "Vestibular";
        this.resumoTopico = "Se você quer praticar exercícios de vestibular e se preparar para" 
                            + " ingressar numa universidade, aqui é o lugar certo.";
        break;
      case "9":
        //this.imagem = "../../../assets/imagens/header/vestibular.png";
        this.resumoTitulo = "Fórum";
        this.resumoTopico = "Aqui você pode discutir Física com outros usuários." 
                            + " Faça questões, responda perguntas, ajude a desvendar os misterios da Física.";
        break;
      case "10":
        //this.imagem = "../../../assets/imagens/header/vestibular.png";
        this.resumoTitulo = "Criar conta";
        this.resumoTopico = "Para acessar o Fórum, comentar nas aulas entre outras funcionalidades é necessário criar uma conta.";
        break;
    }
	}

}
