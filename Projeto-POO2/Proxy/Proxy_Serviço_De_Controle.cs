using System;

public class Proxy_Serviço_De_Controle : IControle
{
    private Servico_de_controle_gastos _servico;

    public Proxy_Serviço_De_Controle(Servico_de_controle_gastos serv){
        _servico = serv;
    }

    public double Calcular_Gasto(Reservas reservas)
    {
        return _servico.Calcular_Gasto(reservas);
    }
}
