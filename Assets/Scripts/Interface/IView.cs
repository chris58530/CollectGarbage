using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IView<T> where T : ISystem
{
       void InitView(T system);

}
