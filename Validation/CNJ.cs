using System;
using System.Globalization;
using String = Filter.String;

namespace Validation
{
    public class Cnj
    {
        private readonly string _cnj;
        private string _cnjSemDigitoVerificador;
        private string _digitoVerificadorCnj;
        private string _resultadoCalculoDigitoVerificadorCnj;
        private string _resultadoCnjCalculado;

        public Cnj(string cnj)
        {
            cnj = String.OnlyNumbers(cnj);

            if (cnj.Length < 20)
            {
                cnj = cnj.PadLeft(20, Convert.ToChar("0"));
            }
            _cnj = cnj;

        }

        public bool IsValid( )
        {
            _cnjSemDigitoVerificador = CnjSemDigitoVerificador();
            _digitoVerificadorCnj = DigitoVerificador();
            _resultadoCalculoDigitoVerificadorCnj = CalculoDigitoVerificador(_cnjSemDigitoVerificador);
            InsereDigitoCalculadoAoCnjSemDigito();
            return ValidaCnj();
        }

        public bool ValidaCnj()
        {
            return _cnj.Equals(_resultadoCnjCalculado);
        }

        public string CnjSemDigitoVerificador()
        {
            return _cnj.Remove(7, 2);
        }

        public string DigitoVerificador()
        {
            return _cnj.Substring(7, 2);
        }

        public string CalculoDigitoVerificador(string cnjSemDigitoVerificador)
        {
            return (98 - (Convert.ToDecimal($"{cnjSemDigitoVerificador}00")%97)).ToString(CultureInfo.CurrentCulture);
        }

        public void InsereDigitoCalculadoAoCnjSemDigito()
        {
            _resultadoCnjCalculado = _cnjSemDigitoVerificador.Insert(7, _resultadoCalculoDigitoVerificadorCnj);
        }



    }
}
