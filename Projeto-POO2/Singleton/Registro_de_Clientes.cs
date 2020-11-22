using System;
using System.Collections.Generic;

public class Registro_de_Clientes
{
    private static Registro_de_Clientes _instancia;
    private List<Clientes> _Clientes_registrados;

    private Registro_de_Clientes(){
        _Clientes_registrados = new List<Clientes>();
        Clientes cli = new Clientes();
        cli.Adicionar_Cliente("AAAAAAA","Green Hill","Grand Metropolis","Hyrule",
                              new DateTime(1991,06,23), "12345", "(24)1234512-123");
        _Clientes_registrados.Add(cli);
        cli = new Clientes();
        cli.Adicionar_Cliente("BBBBBB","Green Hill","Grand Metropolis","Hyrule",
                              new DateTime(1986,11,20), "12345", "(24)1234512-123");
        _Clientes_registrados.Add(cli);
        cli = new Clientes();
        cli.Adicionar_Cliente("CCCCCC","Green Hill","Grand Metropolis","Hyrule",
                              new DateTime(1981,04,24), "12345", "(24)1234512-123");
        _Clientes_registrados.Add(cli);
        cli = new Clientes();
        cli.Adicionar_Cliente("DDDDDDD","Green Hill","Grand Metropolis","Hyrule",
                              new DateTime(1995,11,30), "12345", "(24)1234512-123");
        _Clientes_registrados.Add(cli);
        cli = new Clientes();
        cli.Adicionar_Cliente("EEEEEEE","Green Hill","Grand Metropolis","Hyrule",
                              new DateTime(1993,10,05), "12345", "(24)1234512-123");
        _Clientes_registrados.Add(cli);
    } 

    public static Registro_de_Clientes GetInstancia(){
        if(_instancia == null)
        {
            _instancia = new Registro_de_Clientes();
        }
        return _instancia;
    }

    public Clientes Adicionar_Registro_Cliente(string nome, DateTime data_nascimento){
        Clientes cli = new Clientes();
        
        Console.WriteLine("\nDigite seu Endereço: ");
        string endereco = Console.ReadLine();
        Console.WriteLine("\nDigite seu Cidade: ");
        string cidade = Console.ReadLine();
        Console.WriteLine("\nDigite seu Estado: ");
        string estado = Console.ReadLine();
        Console.WriteLine("\nDigite seu RG: ");
        string rg = Console.ReadLine();
        Console.WriteLine("\nDigite seu Telefone: ");
        string telefone = Console.ReadLine();

        cli.Adicionar_Cliente(nome, endereco, cidade, estado,
                              data_nascimento, rg, telefone);

        _Clientes_registrados.Add(cli);
        return cli;
    }   

    public Clientes Verificar_Registro(string nome, DateTime data_nascimento){
        foreach (var cliente in _Clientes_registrados)
        {
            if(cliente.Get_Nome() == nome && cliente.Get_Data_nasc() == data_nascimento){
                Console.WriteLine("Bem vindo devolta {0}!!", cliente.Get_Nome());
                return cliente;
            }
        }
        Console.WriteLine("\nVocê não está registrado nos nosso sistema, por favor informar seus dados a seguir.");
        Clientes cli = Adicionar_Registro_Cliente(nome, data_nascimento);
        Console.WriteLine("\nVocê foi registrado no nosso sistema.\n");
        return cli;
    }  

    public void Listar_Registrados(){
        foreach (var cliente in _Clientes_registrados){
            Console.WriteLine("Nome do cliente {0}", cliente.Get_Nome());
        }
    }  
}
