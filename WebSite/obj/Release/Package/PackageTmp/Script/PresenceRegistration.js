var activTarget;
var guest;

$(document).ready(function(){
      initEventsPresentation();
});

function initEventsPresentation(){
    initTriggers();
    initRegisterContainers();
    initSelectBox();
}

function initSelectBox(){
    $('.event').each(function(eventIndex,eventObj){
        var target = $(eventObj).attr('target');
        $(eventObj).find('select').each(function(selIndex,selObj){
            attachEvent(target,selObj);
        });
    });
}

function attachEvent(target,selObj){
    $(selObj).change(function(){
        var selectNature = $(this).attr('nature');
        var selectedValue = $(this).find('option:selected').val();
        var selectedText = $(this).find('option:selected').text();
        var targetContainer = $('#Form').find("div[target='"+target+"']");

        var choise = $(targetContainer).find('p.choise');

        if(!$(choise).hasClass('activ')){
            $(choise).addClass('activ');
        }

        var ctrl = $(targetContainer).find('p.'+selectNature);
        $(ctrl).attr('count',selectedValue);
        $(ctrl).html(selectedText);

        if(isValidateShowable()){
            $('.validate').show();
        }
    });
}

function isValidateShowable(){
    var isValidateShowable = true;

    $('#Form').find('.choiseDetail').each(function(pIndex,pElem){
        if($(pElem).text().length == 0){
            isValidateShowable = false;
            return false;
        }
    });

    return isValidateShowable;
}

function initRegisterContainers(){
    $('#Events').find('.event').each(function(containerIndex,container){
        var target = $(container).attr('target');
        $(container).append('<h1>Serez vous des notres ?</h1>');
        var registerSelect = $('<div class="registerContainer"><p>Nombre d\'adultes :</p><select nature="adults"><option disabled selected>Choix</option><option value="1">1 adulte</option><option value="2">2 adultes</option><option value="0">Aucun adulte</option></select></div>');
        $(container).append(registerSelect);

        if(target !== 'Soiree'){
            var registerSelectAdd = '<p>Nombre d\'enfants :</p><select nature="childs"><option disabled selected>Choix</option><option value="1">1 enfant</option><option value="2">2 enfants</option><option value="3">3 enfants</option><option value="0">Aucun enfant</option></select>';
            $(registerSelect).prepend(registerSelectAdd);
        }
    });
}

function initTriggers(){
    $('#Triggers').find('.trigger').each(function(triggerIndex,triggerEl){
        if(!$(triggerEl).hasClass('unselected')){
            activTarget = $(triggerEl).attr('target');
        }

        $(triggerEl).click(function(){
            var target = $(this).attr('target');
            
            if(activTarget !== target){
                $('#Triggers').find("p[target='"+activTarget+"']").addClass('unselected');
                $(this).removeClass('unselected');

                $('#Events').find("div[target='"+activTarget+"']").removeClass('activ');
                $('#Events').find("div[target='"+target+"']").addClass('activ');

                activTarget = target;
            }
        });
    });
}

function setValidation(){
    guest = new Object();

    $('.choiseReminder').each(function(elemIndex,elem){
        switch($(elem).attr('target')){
            case 'Mairie':
            guest.Mairie = new Object();
            guest.Mairie.Childs = $(elem).find('.childs').attr('count');
            guest.Mairie.Adults = $(elem).find('.adults').attr('count');
            break;
            case 'Gouter':
            guest.Gouter = new Object();
            guest.Gouter.Childs = $(elem).find('.childs').attr('count');
            guest.Gouter.Adults = $(elem).find('.adults').attr('count');
            break;
            case 'Soiree':
            guest.Soiree = new Object();
            guest.Soiree.Adults = $(elem).find('.adults').attr('count');
            break;
        }
    });

    alert('Vous serez '+guest.Mairie.Adults+' adultes et '+ guest.Mairie.Childs+' enfants à la Mairie');
    alert('Vous serez '+guest.Gouter.Adults+' adultes et '+ guest.Gouter.Childs+' enfants au Gouter');
    alert('Vous serez '+guest.Soiree.Adults+' adultes à la Soiree');
}