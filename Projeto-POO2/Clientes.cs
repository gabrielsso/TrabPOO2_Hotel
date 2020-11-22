using System;

public class Clientes
{
    private string nome;
    private string _endereco;
    private string _cidade;
    private string _estado;
    private DateTime data_nasc;
    private string _rg;
    private string telefone;
    
    public string Get_Nome()
    {
        return nome;
    }

    public void Set_Nome(string value)
    {
        nome = value;
    }

    private string Get_Endereço()
    {
        return _endereco;
    }

    private void Set_Endereço(string value)
    {
        _endereco = value;
    }

    private string Get_Cidade()
    {
        return _cidade;
    }

    private void Set_Cidade(string value)
    {
        _cidade = value;
    }

    private string Get_Estado()
    {
        return _estado;
    }

    private void Set_Estado(string value)
    {
        _estado = value;
    }

    public DateTime Get_Data_nasc()
    {
        return data_nasc;
    }

    public void Set_Data_nasc(DateTime value)
    {
        data_nasc = value;
    }

    private string Get_RG()
    {
        return _rg;
    }

    private void Set_RG(string value)
    {
        _rg = value;
    }

    public string Get_Telefone()
    {
        return telefone;
    }

    public void Set_Telefone(string value)
    {
        telefone = value;
    }

    public void Adicionar_Cliente(string valueName, string valueEndereco, string valueCidade,
                                  string valueEstado, DateTime valueData_nasc, string valueRG,
                                  string valueTel)
    {
        Set_Nome(valueName);
        Set_Endereço(valueEndereco);
        Set_Cidade(valueCidade);
        Set_Estado(valueEstado);
        Set_Data_nasc(valueData_nasc);
        Set_RG(valueRG);
        Set_Telefone(valueTel);
    }
}
