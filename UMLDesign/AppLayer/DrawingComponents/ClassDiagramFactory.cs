using System;
using System.Collections.Generic;

namespace AppLayer.DrawingComponents
{
    public class ClassDiagramFactory
    {
        private static ClassDiagramFactory _instance;
        private static readonly object MyLock = new object();

        private ClassDiagramFactory() { }

        public static ClassDiagramFactory Instance
        {
            get
            {
                lock (MyLock)
                {
                    if (_instance == null)
                        _instance = new ClassDiagramFactory();
                }
                return _instance;
            }
        }

        public string ResourceNamePattern { get; set; }
        public Type ReferenceType { get; set; }

        private readonly Dictionary<string, ClassDiagramWithIntrinsicState> _sharedTrees = new Dictionary<string, ClassDiagramWithIntrinsicState>();

        public ClassDiagramWithAllState GetTree(ClassDiagramExtrinsicState extrinsicState)
        {
            ClassDiagramWithIntrinsicState treeWithIntrinsicState;
            if (_sharedTrees.ContainsKey(extrinsicState.TreeType))
                treeWithIntrinsicState = _sharedTrees[extrinsicState.TreeType];
            else
            {
                treeWithIntrinsicState = new ClassDiagramWithIntrinsicState();
                string resourceName = string.Format(ResourceNamePattern, extrinsicState.TreeType);
                treeWithIntrinsicState.LoadFromResource(resourceName, ReferenceType);
                _sharedTrees.Add(extrinsicState.TreeType, treeWithIntrinsicState);
            }

            return new ClassDiagramWithAllState(treeWithIntrinsicState, extrinsicState);
        }
    }
}
