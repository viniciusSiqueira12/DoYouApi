using System;

namespace DoYou.Domain.Commands.Proprietario.AutenticarProprietario
{
    public class AutenticarProprietarioResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Autenticado { get; set; }
        public string EmpresaUltimoAcesso { get; set; }

        public static explicit operator AutenticarProprietarioResponse(Entities.Proprietario proprietario)
        {
            return new AutenticarProprietarioResponse()
            {
                Id = proprietario.Id,
                Nome = proprietario.Nome,
                Email = proprietario.Email,
                EmpresaUltimoAcesso = proprietario.EmpresaUltimoAcesso,
                Autenticado = true
            };
        }
    }
}
