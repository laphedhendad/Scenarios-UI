using UnityEngine;

namespace Laphed.ScenariosUI.DependencyInjection
{
    public interface IController
    {
        void Inject(MonoBehaviour root);
    }
}
