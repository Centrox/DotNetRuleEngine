using System.Threading.Tasks;

namespace DotNetRuleEngine.Core.Interface
{
    public interface IRuleAsync<T> : IGeneralRule<T> where T : class, new()
    {
        bool IsParallel { get; set; }

        IParellelConfiguration<T> ParellelConfiguration { get; set; }

        Task InitializeAsync();

        Task BeforeInvokeAsync();

        Task AfterInvokeAsync();
        
        Task<IRuleResult> InvokeAsync();

        Task<object> TryGetValueAsync(string key, int timeoutInMs);

        Task TryAddAsync(string key, Task<object> value);
    }
}