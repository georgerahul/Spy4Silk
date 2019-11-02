using System.Collections.Generic;

namespace K2L.Spy.Viewer.Model
{
    public class ParentModel : ModelBase
    {
        private List<ChildModel> _childModels;

        public ParentModel()
        {
        }

        public List<ChildModel> ChildModels
        {
            get => _childModels;
            set
            {
                _childModels = value;
                OnPropertyChanged("ChildModels");
            }
        }
    }
}