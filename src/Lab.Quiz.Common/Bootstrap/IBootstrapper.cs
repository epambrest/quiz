using System.ComponentModel.Design;

namespace Lab.Quiz.Common.Bootstrap
{
    public interface IBootstrapper
    {
        void Initialize(IServiceContainer container);
    }
}
