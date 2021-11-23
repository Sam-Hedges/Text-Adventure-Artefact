using System;
using System.Collections.Generic;
using System.Text;
using Artefact.InventorySystem;

namespace Artefact.Entity
{
    class Entity
    {
        public string Name { get; private set; }
        public Level LVL { get; private set; }
        public Inventory INV { get; private set; }
        public Health HP { get; private set; }
        public Equipment EQ { get; private set; }
    }
}
