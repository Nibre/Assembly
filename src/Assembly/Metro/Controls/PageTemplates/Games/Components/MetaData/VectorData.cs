namespace Assembly.Metro.Controls.PageTemplates.Games.Components.MetaData
{
	public class VectorData : ValueField
	{
		private float _x, _y, _z;
        private string _labels;
        private string _xLabel, _yLabel, _zLabel;

        public VectorData(string name, uint offset, uint address, float x, float y, float z, string labels, uint pluginLine)
			: base(name, offset, address, pluginLine)
		{
			_x = x;
			_y = y;
			_z = z;
            _labels = labels;
            if(_labels.Length < 3)
            {
                _xLabel = "x";
                _yLabel = "y";
                _zLabel = "z";
            }
            else
            {
                _xLabel = _labels[0].ToString();
                _yLabel = _labels[1].ToString();
                _zLabel = _labels[2].ToString();
            }

        }

		public float X
		{
			get { return _x; }
			set
			{
				_x = value;
				NotifyPropertyChanged("X");
			}
        }

        public float Y
		{
			get { return _y; }
			set
			{
				_y = value;
				NotifyPropertyChanged("Y");
			}
		}

		public float Z
		{
			get { return _z; }
			set
			{
				_z = value;
				NotifyPropertyChanged("Z");
			}
        }

        public string XLabel
        {
            get { return _xLabel; }
            set
            {
                _xLabel = value;
                NotifyPropertyChanged("XLabel");
            }
        }
        public string YLabel
        {
            get { return _yLabel; }
            set
            {
                _yLabel = value;
                NotifyPropertyChanged("YLabel");
            }
        }
        public string ZLabel
        {
            get { return _zLabel; }
            set
            {
                _zLabel = value;
                NotifyPropertyChanged("ZLabel");
            }
        }

        public override void Accept(IMetaFieldVisitor visitor)
		{
			visitor.VisitVector(this);
		}

		public override MetaField CloneValue()
		{
			return new VectorData(Name, Offset, FieldAddress, _x, _y, _z, _labels, base.PluginLine);
		}
	}
}