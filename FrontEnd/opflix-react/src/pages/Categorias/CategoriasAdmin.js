import React,{Component} from 'react';
import logosimples from '../../assets/img/LogoSimples.png';
import Rodape from '../../components/Rodape/Rodape';
import { parseJwt } from "../../services/auth";
import Axios from "axios";
import CategoriasAdminStyle from "./CategoriasAdmin.css";


class CategoriasAdmin extends Component{

    constructor(){
        super();
        this.state = {
            Permissao : ''
        };
        this.state = {
            Categoria : ''
        };

        this.cadastrarCategoria = this.cadastrarCategoria.bind(this);
    }


    
    cadastrarCategoria(event) {
        event.preventDefault();
        fetch("http://192.168.4.209:5000/api/categorias", {
            method: "POST",
            body: JSON.stringify({ Categoria: this.state.Categoria }),
            headers: {
                "Content-Type": "application/json",
                "Accept" : "application/json"
            }
        })
        .then(response => response.json())
        .catch(error => console.log(error));
   }

   atualizarCategoria(event) {
       this.setState({ Categoria: event.target.value })
   }

   componentDidMount(){
    this.setState({Permissao: parseJwt().Permissao})
}



    render(){
        return(
            <div>
                <header className="cabecalhoPrincipal">
                    <div className="container">
                    <img src={logosimples} />

                    <nav className="cabecalhoPrincipal-nav">
                    </nav>
                    </div>
                </header>

                <main className="conteudoPrincipal">
                    <section className="conteudoPrincipal-cadastro">
                    <div className="container" id="conteudoPrincipal-lista">

                    </div>
                   
                        <div className="container" id="conteudoPrincipal-cadastro">
                        <h2 className="conteudoPrincipal-cadastro-titulo">
                        Cadastro de uma Categoria
                        </h2>
                        <form onSubmit={this.cadastrarCategoria }>
                        <div className="container">
                            <input
                            type="text"
                            className="className__categoria"
                            id="input__categoriaC"
                            placeholder="Categoria"
                            value={this.state.Categoria}
                            onChange={this.atualizarCategoria.bind(this)}
                            />
                            <button
                            id="btn__cadastrarC"
                            className="conteudoPrincipal-btn conteudoPrincipal-btn-cadastro"
                            >
                            GO!
                            </button>
                        </div>
                        </form>
                    </div>
                    
                    </section>
                </main>

                {/* <footer className="rodapePrincipal">
                    <section className="rodapePrincipal-patrocinadores">
                    <div className="container">
                        <p>Escola SENAI de Informática - 2019</p>
                    </div>
                    </section>
                </footer> */}
                <Rodape />
                </div>
        );
    }
}

export default CategoriasAdmin;
