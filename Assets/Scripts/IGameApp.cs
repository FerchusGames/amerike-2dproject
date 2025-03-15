using System;
using Cysharp.Threading.Tasks;

namespace DefaultNamespace
{
    public interface IGameApp : IDisposable
    {
        UniTaskVoid StartApp();
    }
}