using System;
using System.Collections.Generic;

public enum Tipo_Quarto{
        simples,
        dupla,
        tripla
}

public class Reservas
{
    private IQuarto _quarto;
    public DateTime dia_entrada;
    public DateTime dia_saida;
    public Clientes cliente;

    public void Registrar_Reserva(){
        try
        {
            Console.WriteLine("\nQual tipo de acomodação quer?");
            Console.WriteLine("1 - Simples\n2 - Dupla\n3 - Tripla");
            int tipo_quarto = int.Parse(Console.ReadLine());
            tipo_quarto = Checar_Opcao(tipo_quarto);
            _quarto = Pegar_Tipo(tipo_quarto);
            if (_quarto == null){
                Console.WriteLine("\nOcorreu uma falha no registro do quarto, por favor refaça.\n");
                return;
            }

            Console.WriteLine("\nQuantos dias irá ficar?");
            int dias = int.Parse(Console.ReadLine());
            dia_entrada = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            dia_saida = Checar_Data(dias);
            Console.WriteLine("\nQual seu nome?");
            String nome = Console.ReadLine();
            Console.WriteLine("\nDia que nasceu?");
            int dia = int.Parse(Console.ReadLine());
            Console.WriteLine("\nMês que nasceu?");
            int mes = int.Parse(Console.ReadLine());
            Console.WriteLine("\nAno que nasceu?");
            int ano = int.Parse(Console.ReadLine());
            DateTime Nascimento = new DateTime(ano,mes,dia);
            cliente = Registro_de_Clientes.GetInstancia().Verificar_Registro(nome, Nascimento);

            Console.WriteLine("Parabéns {0}, sua reserva foi feita com sucesso\n", cliente.Get_Nome());
            return; 
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Gerenciamento_de_Quartos.GetInstancia().Desocupar_Quarto(_quarto);
            return;
        }
        
    }

    public int Checar_Opcao(int opcao){
        while (opcao < 0 || opcao > 3)
        {
            Console.WriteLine("Digite novamente: ");
            opcao = int.Parse(Console.ReadLine());
        }

        return opcao;
    }

    public DateTime Checar_Data(int dias_desejados){
        int Data_calc = DateTime.Now.Day + dias_desejados;
        int date = 0;
        if(Data_calc > 30){
            date = Data_calc - 30;
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, date);
        }

        return new DateTime(DateTime.Now.Year, DateTime.Now.Month, Data_calc);
    }

    public IQuarto Pegar_Tipo(int tipo){
        return _quarto = Gerenciamento_de_Quartos.GetInstancia().Ocupar_Quarto(tipo);
    }

    public IQuarto Get_Quarto(){
        return _quarto;
    }

}
