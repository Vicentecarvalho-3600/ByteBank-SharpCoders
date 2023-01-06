namespace ByteBank1 {

    public class Program {

        static void BemVindo() {
            Console.WriteLine("****************************************");
            Console.WriteLine("*          Bem Vindo ByteBank          *");
            Console.WriteLine("****************************************");
        }

        static void ShowMenu() {
            Console.WriteLine("1 - Inserir novo usuário");
            Console.WriteLine("2 - Deletar um usuário");
            Console.WriteLine("3 - Listar todas as contas registradas");
            Console.WriteLine("4 - Detalhes de um usuário");
            Console.WriteLine("5 - Quantia armazenada no banco");
            Console.WriteLine("6 - Manipular a conta");
            Console.WriteLine("0 - Para sair do programa");
            Console.Write("Digite a opção desejada: ");
        }

        static void ShowMenuContaCliente() {
            Console.WriteLine("1 - Depositar um valor");
            Console.WriteLine("2 - Sacar um valor");
            Console.WriteLine("3 - Transferência");
            Console.WriteLine("0 - Voltar ao menu principal");
            Console.WriteLine("digite a opção desejada: ");
        }

        static void RegistrarNovoUsuario(List<string> cpfs, List<string> titulares, List<string> senhas , List<double> saldos) {
            Console.Write("Digite o cpf: ");
            cpfs.Add(Console.ReadLine());
            Console.Write("Digite o nome: ");
            titulares.Add(Console.ReadLine());
            Console.Write("Digite a senha: ");
            senhas.Add(Console.ReadLine());         
            saldos.Add(0);
        }

        static void DeletarUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos) {
            Console.Write("Digite o cpf: ");
            string cpfParaDeletar = Console.ReadLine();
            int indexParaDeletar = cpfs.FindIndex(cpf => cpf == cpfParaDeletar);
          
            if(indexParaDeletar == -1) {
                Console.WriteLine("Não foi possível deletar esta Conta");
                Console.WriteLine("MOTIVO: Conta não encontrada.");
            }

            cpfs.Remove(cpfParaDeletar);
            titulares.RemoveAt(indexParaDeletar);
            senhas.RemoveAt(indexParaDeletar);
            saldos.RemoveAt(indexParaDeletar);

            Console.WriteLine("Conta deletada com sucesso");
        }

        static void ListarTodasAsContas(List<string> cpfs, List<string> titulares, List<double> saldos) {
            for(int i = 0; i < cpfs.Count; i++) {
                ApresentaConta(i, cpfs, titulares, saldos);
            }
        }

        static void ApresentarUsuario(List<string> cpfs, List<string> titulares, List<double> saldos) {
            Console.Write("Digite o cpf: ");
            string cpfParaApresentar = Console.ReadLine();
            int indexParaApresentar = cpfs.FindIndex(cpf => cpf == cpfParaApresentar);

            if (indexParaApresentar == -1) {
                Console.WriteLine("Não foi possível apresentar esta Conta");
                Console.WriteLine("MOTIVO: Conta não encontrada.");
            }

            ApresentaConta(indexParaApresentar, cpfs, titulares, saldos);
        }

        static void ApresentarValorAcumulado(List<double> saldos) {
            Console.WriteLine($"Total acumulado no banco: {saldos.Sum()}");
            // saldos.Sum(); ou .Agregatte(0.0, (x, y) => x + y)
        }

        static void ApresentaConta( int index, List<string> cpfs, List<string> titulares, List<double> saldos) {
            Console.WriteLine($"CPF = {cpfs[index]} | Titular = {titulares[index]} | Saldo = R${saldos[index]:F2}");
        }

        static void depositarValorEmConta(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos) {
            int index = ValidarUsuario(cpfs, senhas);
            if (index > -1) {
                Console.WriteLine($"Bem-vindo {titulares[index]}");
                Console.Write("digite o valor do deposito: ");
                double valorDeposito = double.Parse(Console.ReadLine());
                while (valorDeposito <= 0) {
                    Console.Write("Valor invalido digite novamente:");
                    valorDeposito = double.Parse(Console.ReadLine());
                }
                saldos[index] += valorDeposito;


            }
          
        }

        static int ValidarUsuario(List<string> cpfs, List<string> senhas) {
            Console.Write("informe seu cpf: ");
            string verificarCfp =Console.ReadLine();
            Console.Write("informe seu sua senha: ");
            string verificarSenha = Console.ReadLine();
            
            int procurarConta = cpfs.FindIndex(cpf => cpf == verificarCfp);
            Console.WriteLine(procurarConta);
            if (procurarConta == -1) {
                Console.WriteLine("Não foi possível acessar esta Conta");
                Console.WriteLine("MOTIVO: Conta não encontrada.");
                return procurarConta;
            } else
            {
                return procurarConta ;
            }
        } 



        public static void Main(string[] args) {


            List<string> cpfs = new List<string>();
            List<string> titulares = new List<string>();
            List<string> senhas = new List<string>();
            List<double> saldos = new List<double>();

            int option;
            BemVindo();
            do {
                
                ShowMenu();
                option = int.Parse(Console.ReadLine());

                Console.WriteLine("-----------------");

                switch (option) {
                    case 0:
                        Console.WriteLine("Estou encerrando o programa...");
                        break;
                    case 1:
                        RegistrarNovoUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case 2:
                        DeletarUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case 3:
                        ListarTodasAsContas(cpfs, titulares, saldos);
                        break;
                    case 4:
                        ApresentarUsuario(cpfs, titulares, saldos);
                        break;
                    case 5:
                        ApresentarValorAcumulado(saldos);
                        break;
                    case 6:
                        int option2;
                        do {
                            ShowMenuContaCliente();
                            option2 = int.Parse(Console.ReadLine());
                            switch(option2) {
                                case 0:
                                    Console.WriteLine("Voltando a menu principal");
                                    break;
                                case 1:
                                    depositarValorEmConta(cpfs, titulares, senhas, saldos);
                                    break;
                                case 2:
                                    break;
                                case 3:
                                    break;

                            }
                            Console.WriteLine("-----------------");
                        } while (option2 != 0);

                        break;

                }

                Console.WriteLine("-----------------");

            } while (option != 0);
            
            

        }

        
    }

}