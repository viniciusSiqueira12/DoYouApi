using DoYou.Domain.Entities.Base;
using DoYou.Domain.Enums;
using System;

namespace DoYou.Domain.Entities
{
    public class EmpregadoEmpresa : EntityBase
    {
        public EmpregadoEmpresa(EnumFuncao funcao, DateTime dataInicio,Empresa empresa, Empregado empregado)
        {
            Funcao = funcao;
            DataInicio = dataInicio;
            Empresa = empresa;
            Empregado = empregado;
        }

        public EnumFuncao Funcao { get; private set; }
        public DateTime  DataInicio { get; private set; }
        public DateTime DataSaida { get; private set; }
        public Empresa Empresa { get; private set; }
        public Empregado Empregado { get; private set; }
    }
}
