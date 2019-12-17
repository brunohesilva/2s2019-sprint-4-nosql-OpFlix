import React,{Component} from 'react';
import logosimples from '../../assets/img/LogoSimples.png';
import Rodape from '../../components/Rodape/Rodape';
import Axios from "axios";


class CategoriasComum extends Component{
   
    constructor() {
        super();
        this.state = {
            lista: []
        };
    }

    componentDidMount() {
        Axios.get('http://192.168.4.209:5000/api/categorias', {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-opflix')
            }
        })
            .then(data => {
                this.setState({ lista: data.data });
                console.log(this.state)
            })
            .catch(erro => {
                console.log(erro);
            });
    }

    render(){
        return(
            <div>
                <header className="cabecalhoPrincipal">
                    <div className="container">
                    <img src={logosimples} />
                    </div>
                </header>

                <main className="conteudoPrincipal">
                    <section className="conteudoPrincipal">
                    <h1 className="conteudoPrincipaltitulo">Categorias</h1>
                    <div className="container" id="conteudoPrincipal-lista">
                    <div className="categorias">
                    {this.state.lista.map(element => {
                        return (
                            <div id="infosC">
                                <ul className="categorias">
                                    {/* <li>{element.idLancamento}</li> */}
                                    <li>Categoria: {element.categoria   }</li>
                                </ul>
                            </div>
                        );
                    })}
                </div>
                    </div>
                    
                    </section>
                </main>

                <Rodape />
                </div>
        );
    }

}

export default CategoriasComum;