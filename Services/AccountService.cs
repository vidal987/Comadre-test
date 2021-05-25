using System.Threading.Tasks;
using System.Linq;
using teste_comadre.Models;
using teste_comadre.Respositories;

namespace teste_comadre.Services
{
    public class AccountService : IAccountService
    {
        private readonly IBaseRepository<Account> accountRepository;
        private readonly ITransactionRepository transactionRepository;

        public AccountService(IBaseRepository<Account> accountRepository, ITransactionRepository transactionRepository)
        {
            this.accountRepository = accountRepository;
            this.transactionRepository = transactionRepository;
        }

        public async Task<bool> Create(Account account)
        {
            return accountRepository.Add(account); 
        }

        public async Task<decimal> GetBalance(int idUser)
        {
            //tP
            //Primeiro buscar saldo inicial 

            var initiaBalance = accountRepository.GetById(idUser).InitialBalance;

            //buscar todas transações do usuario
            var transactions = transactionRepository.GetAllByUser(idUser).Where(t => t.IsCanceled == false);


            //aplicar transações no saldo inicial
            var balance =  transactions.Aggregate(initiaBalance, (acc, t) => 
            {
                if(t.IdSender == idUser)
                {
                    return  acc - t.Value;
                }

                return acc + t.Value;
            });

            //retornar saldo atual
            return balance;
        } 

    }
}