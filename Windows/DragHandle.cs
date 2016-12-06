using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ClipUp.Windows
{
    public enum DragHandleAnchor
    {
        None,
        TopLeft,
        TopCenter,
        TopRight,
        MiddleLeft,
        MiddleRight,
        BottomLeft,
        BottomCenter,
        BottomRight
    }

    public class DragHandle
    {
        public DragHandleAnchor Anchor { get; }
        public Rectangle Bounds { get; set; }

        public DragHandle(DragHandleAnchor anchor)
        {
            this.Anchor = anchor;
        }
    }

    public class DragHandleCollection : IEnumerable<DragHandle>
    {
        private readonly IDictionary<DragHandleAnchor, DragHandle> items = new Dictionary<DragHandleAnchor, DragHandle>
        {
            { DragHandleAnchor.TopLeft, new DragHandle(DragHandleAnchor.TopLeft) },
            { DragHandleAnchor.TopCenter, new DragHandle(DragHandleAnchor.TopCenter) },
            { DragHandleAnchor.TopRight, new DragHandle(DragHandleAnchor.TopRight) },
            { DragHandleAnchor.MiddleLeft, new DragHandle(DragHandleAnchor.MiddleLeft) },
            { DragHandleAnchor.MiddleRight, new DragHandle(DragHandleAnchor.MiddleRight) },
            { DragHandleAnchor.BottomLeft, new DragHandle(DragHandleAnchor.BottomLeft) },
            { DragHandleAnchor.BottomCenter, new DragHandle(DragHandleAnchor.BottomCenter) },
            { DragHandleAnchor.BottomRight, new DragHandle(DragHandleAnchor.BottomRight) }
        };

        public int Count => this.items.Count;

        public DragHandle this[DragHandleAnchor index] => this.items[index];

        public DragHandleAnchor HitTest(Point point)
        {
            return this.Where(h => h.Bounds.Contains(point)).Select(h => h.Anchor).FirstOrDefault();
        }

        public IEnumerator<DragHandle> GetEnumerator()
        {
            return this.items.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
