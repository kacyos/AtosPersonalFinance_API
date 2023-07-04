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
                List<Category> allCategories = new List<Category>
                {
                    new Category
                    {
                        Id = 01,
                        Name = "Salário",
                        Color = "#4CAF50",
                        Icon = "attach_money",
                        Type = "revenue"
                    },
                    new Category
                    {
                        Id = 02,
                        Name = "Rendimento de Investimentos",
                        Color = "#9C27B0",
                        Icon = "show_chart",
                        Type = "revenue"
                    },
                    new Category
                    {
                        Id = 03,
                        Name = "Venda de Produtos",
                        Color = "#FF9800",
                        Icon = "shopping_cart",
                        Type = "revenue"
                    },
                    new Category
                    {
                        Id = 04,
                        Name = "Reembolsos",
                        Color = "#2196F3",
                        Icon = "receipt",
                        Type = "revenue"
                    },
                    new Category
                    {
                        Id = 05,
                        Name = "Aluguéis Recebidos",
                        Color = "#009688",
                        Icon = "home",
                        Type = "revenue"
                    },
                    new Category
                    {
                        Id = 06,
                        Name = "Outros",
                        Color = "#607D8B",
                        Icon = "category",
                        Type = "revenue"
                    },
                    new Category
                    {
                        Id = 07,
                        Name = "Alimentação",
                        Color = "#F44336",
                        Icon = "restaurant",
                        Type = "expense"
                    },
                    new Category
                    {
                        Id = 08,
                        Name = "Moradia (Aluguel/Financiamento)",
                        Color = "#3F51B5",
                        Icon = "home",
                        Type = "expense"
                    },
                    new Category
                    {
                        Id = 09,
                        Name = "Transporte",
                        Color = "#FFC107",
                        Icon = "commute",
                        Type = "expense"
                    },
                    new Category
                    {
                        Id = 10,
                        Name = "Educação",
                        Color = "#2196F3",
                        Icon = "school",
                        Type = "expense"
                    },
                    new Category
                    {
                        Id = 11,
                        Name = "Saúde",
                        Color = "#E91E63",
                        Icon = "local_hospital",
                        Type = "expense"
                    },
                    new Category
                    {
                        Id = 12,
                        Name = "Lazer e Entretenimento",
                        Color = "#673AB7",
                        Icon = "sports_esports",
                        Type = "expense"
                    },
                    new Category
                    {
                        Id = 13,
                        Name = "Compras",
                        Color = "#00BCD5",
                        Icon = "shopping_basket",
                        Type = "expense"
                    },
                    new Category
                    {
                        Id = 14,
                        Name = "Dívidas e Empréstimos",
                        Color = "#FF5722",
                        Icon = "credit_card",
                        Type = "expense"
                    },
                    new Category
                    {
                        Id = 15,
                        Name = "Investimentos",
                        Color = "#795548",
                        Icon = "trending_up",
                        Type = "expense"
                    },
                    new Category
                    {
                        Id = 16,
                        Name = "Doações e Caridade",
                        Color = "#8BC34A",
                        Icon = "favorite",
                        Type = "expense"
                    },
                    new Category
                    {
                        Id = 17,
                        Name = "Outros",
                        Color = "#607D8B",
                        Icon = "category",
                        Type = "expense"
                    }
                };

                List<Category> categories = new List<Category>() { };

                allCategories.ForEach(category =>
                {
                    categories.Add(category);
                });

                return categories;
            }
        }
    }
}
