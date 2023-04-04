﻿using System.Collections.Generic;
using System.Linq;

namespace PROJECT_NAME.Scripts.Extensions
{
  public static class IEmumerableExtentions
  {
    public static T Random<T>(this IEnumerable<T> enumerable)
    {
      var items = enumerable.ToArray();
      return items[UnityEngine.Random.Range(0, items.Length)];
    }
  }
}