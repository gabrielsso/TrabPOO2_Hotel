using System;
using System.Collections.Generic;

public class Gerenciamento_de_Quartos
{
    private static Gerenciamento_de_Quartos _instancia;
    private List<IQuarto> _quartos_disponiveis; 
    private List<IQuarto> _quartos_ocupados; 

    private Gerenciamento_de_Quartos(){
        _quartos_disponiveis = new List<IQuarto>();
        _quartos_ocupados = new List<IQuarto>();
        Adicionar_quartos_a_lista();
    }

    public static Gerenciamento_de_Quartos GetInstancia(){
        if(_instancia == null)
        {
            _instancia = new Gerenciamento_de_Quartos();
        }
        return _instancia;
    }

    private void Adicionar_quartos_a_lista(){
        for (int i = 0; i < 20; i++)
        {
            /*Tipo de quarto: 1 - Simples, 2 - Dupla, 3 - Tripla*/
            int type = 1;
            IQuarto quarto = Registrar_Quarto(type);
            _quartos_disponiveis.Add(quarto);
        }

        for (int i = 0; i < 20; i++)
        {
            /*Tipo de quarto: 1 - Simples, 2 - Dupla, 3 - Tripla*/
            int type = 2;
            IQuarto quarto = Registrar_Quarto(type);
            _quartos_disponiveis.Add(quarto);
        }

        for (int i = 0; i < 20; i++)
        {
            /*Tipo de quarto: 1 - Simples, 2 - Dupla, 3 - Tripla*/
            int type = 3;
            IQuarto quarto = Registrar_Quarto(type);
            _quartos_disponiveis.Add(quarto);
        }
    }

    private IQuarto Registrar_Quarto(int type){
        IQuarto quarto = null;
        switch (type)
        {
            case 1:{
                quarto = new Quartos_simples();
                break;
            }
            case 2:{
                quarto = new Quartos_dupla();
                break;
            }
            case 3:{
                quarto = new Quartos_tripla();
                break;
            }
            default:
                Console.WriteLine("Ocorreu um erro no gerenciamento de quartos(Registro de quartos)");
                break;
        }

        bool check = true;
        while (check)
        {
            if(_quartos_disponiveis.Count == 0){
                check = false;
            }

            foreach (var item in _quartos_disponiveis)
            {
                if (quarto.Num_quarto == item.Num_quarto)
                {
                    check = true;
                    quarto.Reroll_Number();
                }else{
                    check = false;
                }
            }
        }

        return quarto;
    }

    public void Listar_Quartos_Disponiveis(int i){
        Console.WriteLine("\nQuartos disponiveis:");
        string Tipo_quarto;
        if (i == 1)
        {
            Tipo_quarto = "Simples";
        }else if(i == 2){
            Tipo_quarto = "Dupla";
        }else{
            Tipo_quarto = "Tripla";
        }
        
        foreach (var item in _quartos_disponiveis)
        {
            if(Tipo_quarto == item.Tipo_quarto)
            Console.WriteLine("Quarto Nº{0} - Tipo: {1}",item.Num_quarto, item.Tipo_quarto);
        }
    }

    public IQuarto Ocupar_Quarto(int i){
        Listar_Quartos_Disponiveis((int) i);
        Console.WriteLine("Digite o quarto que deseja: ");
        int number = int.Parse(Console.ReadLine());
        IQuarto quarto = Verificiar_Quarto(number);
        if (quarto == null)
        {
            Console.WriteLine("\nNúmero do quarto inválido.\n");
            return null;
        }

        _quartos_disponiveis.Remove(quarto);
        _quartos_ocupados.Add(quarto);
        return quarto;
    }

    public void Desocupar_Quarto(IQuarto quarto){
        quarto.reset_serviço();
        _quartos_ocupados.Remove(quarto);
        _quartos_disponiveis.Add(quarto);
    }

    private IQuarto Verificiar_Quarto(int i){
        foreach (var item in _quartos_disponiveis)
        {
            if(item.Num_quarto == i){
                return item;
            }
        }

        return null;
    }
}
