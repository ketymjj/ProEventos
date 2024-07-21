import { Lote } from "./Lote";
import { RedeSocial } from "./RedeSocial";

export interface Evento {
lotes: any;

    id: number;
    local: string;
    dataEvento?: Date;
    tema: string;
    qtdPessoas:number;
    imagemURL: string;
    telefone: string;
    email: string;
    lote: Lote[] ;
    redesSociais: RedeSocial[];
}
