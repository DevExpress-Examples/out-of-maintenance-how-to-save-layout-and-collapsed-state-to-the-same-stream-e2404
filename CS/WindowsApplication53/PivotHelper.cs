using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraPivotGrid;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsApplication53
{
    public class PivotLayoutHelper
    {
        public static void SavePivot(PivotGridControl pivot, Stream stream)
        {
            Storage s = new Storage();
            using (MemoryStream layoutStream = new MemoryStream())
            {
                pivot.SaveLayoutToStream(layoutStream, OptionsLayoutPivotGrid.FullLayout);
                s.layout = layoutStream.ToArray();
            }
            using (MemoryStream stateStream = new MemoryStream())
            {
                pivot.SaveCollapsedStateToStream(stateStream);
                s.collapsedState = stateStream.ToArray();
            }
            BinaryFormatter binFormat = new BinaryFormatter();
            binFormat.Serialize(stream, s);

        }
        public static void LoadPivot(PivotGridControl pivot, Stream stream)
        {
            Storage s = new Storage();

            BinaryFormatter binFormat = new BinaryFormatter();
            s = binFormat.Deserialize(stream) as Storage;

            using (MemoryStream layoutStream = new MemoryStream())
            {
                layoutStream.Write(s.layout, 0, s.layout.Length);
                layoutStream.Position = 0;
                pivot.RestoreLayoutFromStream(layoutStream, OptionsLayoutPivotGrid.FullLayout);

            }
            using (MemoryStream stateStream = new MemoryStream())
            {
                stateStream.Write(s.collapsedState, 0, s.collapsedState.Length);
                stateStream.Position = 0;
                pivot.LoadCollapsedStateFromStream(stateStream);
            }

        }

        [Serializable]
        public class Storage
        {
            public byte[] layout;
            public byte[] collapsedState;
        }
    }
}
