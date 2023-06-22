using AtosPersonalFinance_API.Models.Entities;

namespace AtosPersonalFinance_API.Data
{
    public class CategoryDefault
    {
        /// <summary>
        /// Gera e retorna as categorias padrões do sistema
        /// </summary>
        public static List<Category> generate()
        {
            using (var context = new Context())
            {
                List<Category> categories = new List<Category>();

                List<string> revenueCategories = new List<string>
                {
                    "Salário",
                    "Rendimento de Investimentos",
                    "Venda de Produtos",
                    "Reembolsos",
                    "Aluguéis Recebidos",
                    "Outros"
                };

                List<string> expenseCategories = new List<string>
                {
                    "Alimentação",
                    "Moradia (Aluguel/Financiamento)",
                    "Transporte",
                    "Educação",
                    "Saúde",
                    "Lazer e Entretenimento",
                    "Compras",
                    "Dívidas e Empréstimos",
                    "Investimentos",
                    "Doações e Caridade",
                    "Outros"
                };

                for (int i = 0; i < revenueCategories.Count; i++)
                {
                    categories.Add(
                        new Category
                        {
                            Id = i + 1,
                            Name = revenueCategories[i],
                            Type = "revenue"
                        }
                    );
                    ;
                }

                for (int i = 0; i < expenseCategories.Count; i++)
                {
                    categories.Add(
                        new Category
                        {
                            Id = (revenueCategories.Count + (i + 1)),
                            Name = expenseCategories[i],
                            Type = "Expense",
                        }
                    );
                }

                return categories;
            }
        }
    }
}
