using System;
using System.Collections.Generic;
using UnityEngine;

namespace UserInterface
{
    public class ToggleablePanelCollection : MonoBehaviour
    {
        public List<ToggleablePanel> allPanels;
        public static List<ToggleablePanel> AllPanels;

        private void Awake() => AllPanels = allPanels;
    }
}
