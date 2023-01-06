namespace ByteBank1 {

    public class Program {

        static void BemVindo() {
            Console.WriteLine("****************************************");
            Console.WriteLine("*          Bem Vindo ByteBank          *");
            Console.WriteLine("****************************************");
        }

        static void ShowMenu() {
            Console.WriteLine("[1] - Inserir novo usuário");
            Console.WriteLine("[2] - Deletar um usuário");
            Console.WriteLine("[3] - Listar todas as contas registradas");
            Console.WriteLine("[4] - Detalhes de um usuário");
            Console.WriteLine("[5] - Quantia armazenada no banco");
            Console.WriteLine("[6] - Manipular a conta");
            Console.WriteLine("[0] - Para sair do programa");
            Console.Write("Digite a opção desejada: ");
        }

        static void ShowMenuContaCliente() {
            Console.WriteLine("1 - Depositar um valor");
            Console.WriteLine("2 - Sacar um valor");
            Console.WriteLine("3 - Transferência");
            Console.WriteLine("0 - Voltar ao menu principal");
            Console.Write("digite a opção desejada: ");
        }

        static void RegistrarNovoUsuario(List<string> cpfs, List<string> titulares, List<string> senhas , List<double> saldos) {
            Console.Write("Digite o cpf: ");
            cpfs.Add(Console.ReadLine());
            Console.Write("Digite o nome: ");
            titulares.Add(Console.ReadLine());
            Console.Write("Digite a senha: ");
            senhas.Add(Console.ReadLine());
            Console.Write("Deseja adicionar um saldo inicial[1-sim 2-não]: ");
            int opcao = int.Parse(Console.ReadLine());
            if (opcao == 1) {
                Console.Write("informe seu deposito inicial: ");
                double saldoInicial = double.Parse(Console.ReadLine());
                if (saldoInicial <= 0) {
                    Console.WriteLine("valor invalido");
                    saldos.Add(0);
                }
                if(saldoInicial > 0) {
                    saldos.Add(saldoInicial);
                }
            } else {
                saldos.Add(0);
            }
            
        }

        static void DeletarUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos) {
            Console.Write("Digite o cpf: ");
            string cpfParaDeletar = Console.ReadLine();
            int indexParaDeletar = cpfs.FindIndex(cpf => cpf == cpfParaDeletar);

            if (indexParaDeletar == -1) {
                Console.WriteLine("Não foi possível deletar esta Conta");
                Console.WriteLine("MOTIVO: Conta não encontrada.");
            }
            else {

                cpfs.Remove(cpfParaDeletar);
                titulares.RemoveAt(indexParaDeletar);
                senhas.RemoveAt(indexParaDeletar);
                saldos.RemoveAt(indexParaDeletar);

                Console.WriteLine("Conta deletada com sucesso");
            }
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

        static void DepositarValorEmConta(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos) {
            int index = ValidarUsuario(cpfs, senhas);
            if (index > -1) {
                Console.WriteLine($"Bem-vindo {titulares[index]} Saldo: {saldos[index]}");
                Console.Write("digite o valor do deposito: ");
                double valorDeposito = double.Parse(Console.ReadLine());
                if (valorDeposito <= 0) {
                    Console.Write("Valor do deposito e invalido");
                    valorDeposito = double.Parse(Console.ReadLine());
                }
                if (valorDeposito > 0) {
                    saldos[index] += valorDeposito;
                    Console.WriteLine("Deposito realizado com sucesso");
                }
            }
        }

        static void SacarValorEmConta(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos) {
            int index = ValidarUsuario(cpfs, senhas);
            if (index > -1) {
                Console.WriteLine($"Bem-vindo {titulares[index]} Saldo: {saldos[index]}");
                Console.Write("digite o valor do saque: ");
                double valorSaque = double.Parse(Console.ReadLine());
                if (valorSaque <= 0) {
                    Console.WriteLine("Valor de saque é invalido");
             
                }
                if (saldos[index] <= valorSaque) {
                    Console.WriteLine("saldo e insuficiente");
                }
                if (saldos[index] >= valorSaque) {
                    Console.WriteLine("saque e efetuado com sucesso");
                }

            }   
        }

        static void TransferenciaValorEmConta(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos) {
            int index = ValidarUsuario(cpfs, senhas);
            if (index > -1) {
                Console.WriteLine($"Bem-vindo {titulares[index]} Saldo: {saldos[index]}");
                Console.Write("digite o valor da Tranferencia: ");
                double valorTranferencia = double.Parse(Console.ReadLine());

                if (valorTranferencia <= 0) {
                    Console.WriteLine("Valor de transferencia é invalido");

                }
                if (saldos[index] <= valorTranferencia) {
                    Console.WriteLine("saldo e insuficiente");
                }
                if (saldos[index] >= valorTranferencia ) {
                    Console.Write("informe o cpf do cliente:");
                    string cpfDaTransferenica = Console.ReadLine();
                    int indexTranferencia = cpfs.FindIndex(cpf => cpf == cpfDaTransferenica);
                    if (indexTranferencia == -1) {
                        Console.WriteLine("Não realizar a transferencia para esta Conta");
                        Console.WriteLine("MOTIVO: Conta não encontrada.");
                    }
                    if (indexTranferencia >= 0) {
                        Console.WriteLine("Transferencia realizada com sucesso");
                        saldos[indexTranferencia] += valorTranferencia;
                    }

                }
            }

        }

        static int ValidarUsuario(List<string> cpfs, List<string> senhas) {
            Console.Write("informe seu cpf: ");
            string verificarCfp =Console.ReadLine();
            Console.Write("informe seu sua senha: ");
            string verificarSenha = Console.ReadLine();
            
            int idIndex = cpfs.FindIndex(cpf => cpf == verificarCfp);           
            if (idIndex == -1) {
                Console.WriteLine("Não foi possível acessar esta Conta");
                Console.WriteLine("MOTIVO: Conta não encontrada.");
                return idIndex;
            } else
            {
                return idIndex ;
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

                Console.WriteLine();
                Console.WriteLine("-----------------");
                Console.WriteLine();

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
                                    DepositarValorEmConta(cpfs, titulares, senhas, saldos);
                                    break;
                                case 2:
                                    SacarValorEmConta(cpfs, titulares, senhas, saldos);
                                    break;
                                case 3:
                                    TransferenciaValorEmConta(cpfs, titulares, senhas, saldos);
                                    break;
                                default:
                                    Console.WriteLine("Operação invalida!");
                                    break;

                            }
                            Console.WriteLine();
                            Console.WriteLine("-----------------");
                            Console.WriteLine();
                        } while (option2 != 0);
                        break;
                    default:
                        Console.WriteLine("Operação invalida!");
                        break;

                }
                Console.WriteLine();
                Console.WriteLine("-----------------");
                Console.WriteLine();

            } while (option != 0);
            
            

        }


    }

}