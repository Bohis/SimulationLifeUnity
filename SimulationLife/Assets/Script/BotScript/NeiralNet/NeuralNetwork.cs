using System;

namespace NeiralNet {
	/// <summary> 
	/// Класс перцетрона  
	/// </summary> 
	public class NeuralNetwork : Tree.IKnot{
		#region Состав сети
		/// <summary>
		/// Входной слой
		/// </summary>
		private InputLayer _first;
		/// <summary>
		/// Скрытый слой 
		/// </summary>
		private HiddenLayer _second;
		/// <summary>
		/// Выходной слой
		/// </summary>
		private OutputLayer _third;
		/// <summary>
		///	Слой синапсов 
		/// </summary>
		private SynapseLayer _sFirst;
		/// <summary>
		///	Слой синапсов 
		/// </summary>
		private SynapseLayer _sSecond;
		#endregion

		/// <summary>
		/// Коофициент 
		/// обучения </summary>
		private int _trainigCoof;

		public float ValueCrit;
		///<summary> 
		/// Конструктор для наследования  
		///</summary>
		public NeuralNetwork(int trainigCoof, float [,] sFirst, float [,] sSecond) {
			_first = new InputLayer( 6 );

			_second = new HiddenLayer( 2 );

			_third = new OutputLayer( 6 );

			_sFirst = new SynapseLayer( 6, 2 );

			_sSecond = new SynapseLayer( 2, 6 );

			this._sFirst = new SynapseLayer( sFirst, trainigCoof, true );

			this._sSecond = new SynapseLayer( sSecond, trainigCoof, true );

			this._trainigCoof = trainigCoof;
			ValueCrit = 0;
		}
		/// <summary> 
		/// Конструктор с параметром обучения нейросети
		/// </summary>
		public NeuralNetwork(int trainigCoof) {
			_first = new InputLayer( 6 );

			_second = new HiddenLayer( 2 );

			_third = new OutputLayer( 6 );

			_sFirst = new SynapseLayer( 6, 2 );

			_sSecond = new SynapseLayer( 2, 6 );

			this._trainigCoof = trainigCoof;
			ValueCrit = 0;
		}
		/// <sumarry> 
		/// Конструктор для наследования нейросети 
		/// </sumarry>
		public NeuralNetwork(NeuralNetwork baseNet, bool triggerTrain) {
			_first = new InputLayer( 6 );

			_second = new HiddenLayer( 2 );

			_third = new OutputLayer( 6 );

			_sFirst = new SynapseLayer( 6, 2 );

			_sSecond = new SynapseLayer( 2, 6 );

			_trainigCoof = baseNet.TraingCoof;

			_sFirst = new SynapseLayer( baseNet.SFirst, baseNet.TraingCoof, triggerTrain );

			_sSecond = new SynapseLayer( baseNet.SSecond, baseNet.TraingCoof, triggerTrain );
			ValueCrit = 0;

		}
		///<sumarry> 
		///Метод работы нейросети, с результатом хеш-строки 
		///</sumarry> 		
		public float[,] WorkNet(float [] hashArray) {
			_first.InputDate( hashArray );

			_second.Matrix = Matrix.Multiplication( _first.Matrix, _sFirst.Matrix );
			_second.Formalize();

			_third.Matrix = Matrix.Multiplication( _second.Matrix, _sSecond.Matrix );
			_third.Formalize();

			return _third.OutputDate();
		}

		///<sumarry> 
		///Коофициент обучения 
		///</sumarry>
		public int TraingCoof {
			get { return _trainigCoof; }
		}
		///<sumarry> 
		///Свойства для наследования 
		///</sumarry>
		public float [,] SFirst {
			get { return _sFirst.Matrix; }
		}
		///<sumarry> 
		///Свойства для наследования 
		///</sumarry>
		public float [,] SSecond {
			get { return _sSecond.Matrix; }
		}

		static public NeuralNetwork Mixing(NeuralNetwork web1, NeuralNetwork web2) {
			SynapseLayer first = new SynapseLayer( web1.SFirst.GetLength( 0 ), web1.SFirst.GetLength( 1 ) );
			SynapseLayer second = new SynapseLayer( web1.SSecond.GetLength( 0 ), web1.SSecond.GetLength( 1 ) );

			for (int i = 0 ; i < first.N ; ++i) {
				for (int j = 0 ; j < first.M ; ++j) {
					first.Matrix [ i, j ] = ( web1.SFirst [ i, j ] + web2.SFirst [ i, j ] ) / 2f;
				}
			}

			for (int i = 0 ; i < second.N ; ++i) {
				for (int j = 0 ; j < second.M ; ++j) {
					second.Matrix [ i, j ] = ( web1.SSecond [ i, j ] + web2.SSecond [ i, j ] ) / 2f;
				}
			}

			return new NeuralNetwork( web1.TraingCoof, first.Matrix, second.Matrix );
		}

		public float CriticalValues() {
			return ValueCrit;
		}
	}
}