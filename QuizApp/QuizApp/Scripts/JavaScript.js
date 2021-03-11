function CreateUrl(category)
{
var url = 'https://opentdb.com/api.php?';
var amount = '1'
var category = category
var difficulty = 'medium'
var type = 'multiple'

urlString = `${url}amount=${amount}&category=${category}&difficulty=${difficulty}&type=${type}`

var random = Math.floor(Math.random() * 4);
console.log(random);

jQuery.getJSON(urlString, function (result) {
    var question_data = result.results[0]
    var question1 = question_data.question
    $(".question").append(question1)
    var answers = question_data.incorrect_answers;
    var correct_answer = question_data.correct_answer
    answers.splice(random, 0, correct_answer);
    $(".answer0").append(answers[0])
    $(".answer1").append(answers[1])
    $(".answer2").append(answers[2])
    $(".answer3").append(answers[3])
});

}


