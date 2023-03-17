using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AoV
{
    public partial class GameEntry : MonoBehaviour
    {
        private void Start()
        {
            InitBuiltinComponents();
            InitCustomComponents();
        }
    }
}
