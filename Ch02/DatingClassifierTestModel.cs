namespace kNN
{
    class DatingClassifierTestModel
    {
        public string ResultMessage { get; set; }

        public DatingClassifierTestModel()
        {
            double errorRate = KNNClassifier.GetErrorRate();
            ResultMessage = "the total error rate is " + errorRate + "%";
        }
    }
}
