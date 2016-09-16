using System;

namespace Assembly.Metro.Controls.PageTemplates.Games.Components.MetaData
{
	public class VectorData : ValueField
	{
		private float _x, _y, _z;
        private string _labels;
        private string _xLabel, _yLabel, _zLabel;
        private string _typeLabel;
        private bool _degrees;

        public VectorData(string name, uint offset, uint address, float x, float y, float z, string labels, bool degrees, uint pluginLine)
            : base(name, offset, address, pluginLine)
        {
            _x = x;
            _y = y;
            _z = z;

            _labels = labels;
            _degrees = degrees;
            
            if (_labels.Length < 3)
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

            if (_degrees)
                _typeLabel = "vector3D";
            else
                _typeLabel = "vector3F";
        }
        
        public float XVal
        {
            get
            {
                if (_degrees)
                    return (float)(_x * (180 / Math.PI));
                else
                    return _x;
            }
            set
            {
                if (_degrees)
                    _x = (float)(value * (Math.PI / 180));
                else
                    _x = value;

                NotifyPropertyChanged("X");
                NotifyPropertyChanged("XVal");
            }
        }

        public float X
		{
			get
            {
                return _x;
            }
			set
			{
                _x = value;
				NotifyPropertyChanged("X");
                NotifyPropertyChanged("XVal");
            }
        }

        public float YVal
        {
            get
            {
                if (_degrees)
                    return (float)(_y * (180 / Math.PI));
                else
                    return _y;
            }
            set
            {
                if (_degrees)
                    _y = (float)(value * (Math.PI / 180));
                else
                    _y = value;

                NotifyPropertyChanged("Y");
                NotifyPropertyChanged("YVal");
            }
        }

        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
                NotifyPropertyChanged("Y");
                NotifyPropertyChanged("YVal");
            }
        }

        public float ZVal
        {
            get
            {
                if (_degrees)
                    return (float)(_z * (180 / Math.PI));
                else
                    return _z;
            }
            set
            {
                if (_degrees)
                    _z = (float)(value * (Math.PI / 180));
                else
                    _z = value;

                NotifyPropertyChanged("Z");
                NotifyPropertyChanged("ZVal");
            }
        }

        public float Z
        {
            get
            {
                return _z;
            }
            set
            {
                _z = value;
                NotifyPropertyChanged("Z");
                NotifyPropertyChanged("ZVal");
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

        public string TypeLabel
        {
            get { return _typeLabel; }
            set
            {
                _zLabel = value;
                NotifyPropertyChanged("TypeLabel");
            }
        }

        public override void Accept(IMetaFieldVisitor visitor)
		{
			visitor.VisitVector(this);
		}

		public override MetaField CloneValue()
		{
			return new VectorData(Name, Offset, FieldAddress, _x, _y, _z, _labels, _degrees, base.PluginLine);
		}
	}
}