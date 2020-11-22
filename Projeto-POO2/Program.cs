using System;

namespace Projeto_POO2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Bem vindo ao programa\n");
            Registro_de_Clientes rc = Registro_de_Clientes.GetInstancia();       
            Gerenciamento_de_reservas gr = new Gerenciamento_de_reservas();
            Gerenciamento_de_Quartos gq = Gerenciamento_de_Quartos.GetInstancia();
            int choice = 0;
            
            while (choice != 5)
            {
                Console.WriteLine("Escolha umas das opções:");
                Console.WriteLine("1 - Adicionar uma Reservas");
                Console.WriteLine("2 - Pedir Serviços de Hospedes");
                Console.WriteLine("3 - Fecha uma conta");
                Console.WriteLine("4 - Relátorios Diário");
                Console.WriteLine("5 - Sair");

                try
                {
                    choice = int.Parse(Console.ReadLine());
                    if(choice != 5){
                        Menu(choice, gr);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("\nDigite apenas números\n");
                    choice = 0;
                }

            }
        }

        public static void Menu(int choice, Gerenciamento_de_reservas gr){
            
            if(choice > 5 || choice < 0){
                Console.WriteLine("\nInsira uma opção valida...\n");
                return;
            }

            switch(choice){
                case 1:
                    gr.Adicionar_Reserva();
                    break;
                case 2:
                    gr.Pedir_Serviço();
                    break;
                case 3:
                    gr.Fechar_Conta();
                    break;
                case 4:
                    Relatorio rela = new Relatorio();
                    rela.Relatorio_Diario(gr);
                    break;
                default:
                    Console.WriteLine("\nOcorreu um problema no sistema.\n");
                    break;
            }
        }
    }
}
