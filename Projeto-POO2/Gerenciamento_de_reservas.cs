using System;
using System.Collections.Generic;

public class Gerenciamento_de_reservas
{
    private List<Reservas> lista_de_reservas = new List<Reservas>();

    public void Adicionar_Reserva(){
        Reservas reserv = new Reservas();
        reserv.Registrar_Reserva();
        lista_de_reservas.Add(reserv);
    }

    public void Fechar_Conta(){
        Listar_Reservas();
        Console.WriteLine("\nEscreva o número do quarto que deseja fechar a reserva: ");
        int room_number = int.Parse(Console.ReadLine());
        Reservas reserva = Get_Reserva(room_number);
        if(reserva == null){
            return;
        }

        Console.WriteLine("\nObrigado por usar os nossos serviçoes, iremos dá o valor total da estádia: ");
        Servico_de_controle_gastos serv = new Servico_de_controle_gastos();
        Proxy_Serviço_De_Controle proxy = new Proxy_Serviço_De_Controle(serv);
        Controle_financeiro cf = new Controle_financeiro();

        double total = proxy.Calcular_Gasto(reserva);

        Console.WriteLine("\nO gasto total da reserva com 5% incluso do nosso serviço é de: R${0:0.00}", total);
        cf.Pagamento(total, total);
        Gerenciamento_de_Quartos.GetInstancia().Desocupar_Quarto(reserva.Get_Quarto());
        lista_de_reservas.Remove(reserva);
    }

    public void Listar_Reservas(){
        Console.WriteLine("\nReservas registradas:");
        foreach (var reserva in lista_de_reservas)
        {
            Console.WriteLine("Quarto {0} - Tipo: {1}, Reservado por {2}", reserva.Get_Quarto().Num_quarto, reserva.Get_Quarto().Tipo_quarto, reserva.cliente.Get_Nome());
        }
    }

    public void Pedir_Serviço(){
        Listar_Reservas();
        Console.WriteLine("\nEscreva o número do quarto que deseja o pedido: ");
        int room_number = int.Parse(Console.ReadLine());
        Reservas reserva = Get_Reserva(room_number);
        IQuarto quarto = reserva.Get_Quarto();
        if(reserva == null){
            return;
        }
        Console.WriteLine("\nGostaria de pedir qual serviço?");
        Console.WriteLine("1 - Comida, 2 - Telefone");
        int choice = int.Parse(Console.ReadLine());
        if (choice < 0 || choice > 2)
        {
            Console.WriteLine("Serviço inválido");
            return;
        }

        switch(choice){
            case 1:{
                quarto.pedir_comida();
                break;
            }
            case 2:{
                quarto.usar_telefone();
                break;
            }
            default:
                Console.WriteLine("\nOcorreu um problema na decisão do serviço\n");
                break;
        }
    }

    public Reservas Get_Reserva(int room_number){
        foreach (var reserva in lista_de_reservas)
        {
            if(reserva.Get_Quarto().Num_quarto == room_number)
            return reserva;
        }

        Console.WriteLine("\nO número do quarto está invalido.\n");
        return null;
    }
    
    public void Listar_Gastos_Atuais(){
        if(lista_de_reservas.Count == 0){
            Console.WriteLine("\nNão possui nenhuma reserva registrada no sistema.\n");
            return;
        }

        foreach (var reserva in lista_de_reservas)
        {
            int quarto_num = reserva.Get_Quarto().Num_quarto;
            string cli_nome = reserva.cliente.Get_Nome();
            Console.WriteLine("\nOs gastos atuais do quarto {0} do cliente {1}, são de:", quarto_num, cli_nome);
            Servico_de_controle_gastos serv = new Servico_de_controle_gastos();
            Proxy_Serviço_De_Controle proxy = new Proxy_Serviço_De_Controle(serv);
            double total = proxy.Calcular_Gasto(reserva);
            Console.WriteLine("\nO gasto total atual da reserva com 5% incluso do nosso serviço é de: R${0:0.00}\n", total);
        }
    }
}
